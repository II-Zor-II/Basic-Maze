
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;

    private GameObject mainCamera;

    private GridGenerator gridGenerator;

    [HideInInspector]
    public bool playerInstantiated = false;

    // Please Drag and Assign a prefab to the player gameobject property
    // in the game manager
    // use the Sphere prefab if you don't have one
    public GameObject player;

    public GameObject[,] grid;
    public GameObject maze;
    public GridCell spawnPoint = null;
    public GridCell finishingPoint = null;

    public int rows = 4;
    public int col = 4;

    public static GameManager Instance
    {
        get { return _instance;  }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        gameObject.name = "Game Manager";
        InitializeGame();
    }

    void InitializeGame() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.AddComponent<GridGenerator>();
        gridGenerator = GetComponent<GridGenerator>();
        grid = gridGenerator.Generate(rows,col);
        CreateMaze();
        maze.AddComponent<MazeBoardController>();
        maze.AddComponent<GameOverController>();
    }

    void CreateMaze()
    {
        gameObject.AddComponent<DsRecursiveBT>();
        maze = new GameObject("Maze");
        maze.tag = "MazeBoard";
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < col; j++) {
                grid[i, j].transform.parent = maze.transform;
            }
        }
    }
    void SpawnPlayer()
    {
        if (spawnPoint != null && finishingPoint != null && !playerInstantiated)
        {
            GameObject playerClone = Instantiate(player) as GameObject;
            playerClone.name = "Player-Sphere";
            playerClone.tag = "Player";
            playerClone.transform.parent = maze.transform;
            playerInstantiated = true;
            playerClone.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 3, spawnPoint.transform.position.z);
            playerClone.transform.LookAt(finishingPoint.transform.position);
            mainCamera.AddComponent<CameraController>();
        }
    }

    private void LateUpdate()
    {
       SpawnPlayer();
    }

}
