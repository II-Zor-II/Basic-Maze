
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;

    private GameObject mainCamera;

    private GridGenerator gridGenerator;
    private bool playerInstantiated = false;

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

        InitializeGame();
    }

    void InitializeGame() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
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
            player = Instantiate(player) as GameObject;
            player.transform.parent = maze.transform;
            playerInstantiated = true;
            player.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 3, spawnPoint.transform.position.z);
            player.transform.LookAt(finishingPoint.transform.position);
            mainCamera.AddComponent<CameraController>();
        }
    }

    private void LateUpdate()
    {
       SpawnPlayer();
    }

}
