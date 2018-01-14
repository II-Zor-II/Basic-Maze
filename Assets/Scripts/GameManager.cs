
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;

    private GridGenerator gridGenerator;

    public GameObject[,] grid;
    public GameObject maze;

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
        gridGenerator = GetComponent<GridGenerator>();
        grid = gridGenerator.Generate(rows,col);
        CreateMaze();
        SpawnPlayer();
    }

    void CreateMaze()
    {
        gameObject.AddComponent<DsRecursiveBT>();
        maze = new GameObject("Maze");
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < col; j++) {
                grid[i, j].transform.parent = maze.transform;
            }
        }
    }

    void SpawnPlayer()
    {

    }
}
