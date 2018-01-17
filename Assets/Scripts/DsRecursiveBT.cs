using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DsRecursiveBT : MonoBehaviour {

    protected List<GridCell> neighborCells;
    protected GameObject[,] grid;

    protected Stack<GridCell> cellStack = new Stack<GridCell>();

    private GridCell currentCell = null;

    private int rowIndex, colIndex;
    private bool finishedAlgo = false;

    private void Awake()
    {
        this.grid = gameObject.GetComponent<GameManager>().grid;
        SetStartingCell();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //Debug.Log(currentCell.visited);
        if (currentCell != null)
        {
            currentCell.visited = true;
        }

        neighborCells = GridUtility.GetUnvisitedCellNeighbors(grid, currentCell.rowIndex, currentCell.colIndex);
        if (neighborCells.Count > 0) {
            int r = UnityEngine.Random.Range(0, neighborCells.Count);
            RemoveWalls(currentCell, neighborCells[r]);
            currentCell = neighborCells[r];
            rowIndex = currentCell.rowIndex;
            colIndex = currentCell.colIndex;
            cellStack.Push(currentCell);
        }
        else if (cellStack.Count > 0)
        {
            currentCell = cellStack.Pop();
        }
        else
        {
            finishedAlgo = true;
        }
        if (finishedAlgo)
        {
            Destroy(gameObject.GetComponent<DsRecursiveBT>());
        }
    }

    private void OnDestroy()
    {
        int rows = gameObject.GetComponent<GameManager>().rows;
        rowIndex = UnityEngine.Random.Range(0, rows - 1);
        colIndex = grid.GetLength(1) - 1;
        gameObject.GetComponent<GameManager>().finishingPoint = grid[rowIndex, colIndex].GetComponentInParent<GridCell>();
        grid[rowIndex, colIndex].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.cyan;
        grid[rowIndex, colIndex].GetComponentInParent<GridCell>().DestroyWall("east");
        GameObject EndPointCollider = GameObject.CreatePrimitive(PrimitiveType.Cube);
        EndPointCollider.GetComponent<MeshFilter>().mesh.Clear();
        EndPointCollider.GetComponent<Collider>().isTrigger = true;
        EndPointCollider.name = "EndPoint";
        EndPointCollider.transform.parent = grid[rowIndex, colIndex].GetComponentInParent<GridCell>().floor.transform;
        EndPointCollider.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z);
        EndPointCollider.transform.position = grid[rowIndex, colIndex].GetComponentInParent<GridCell>().floor.transform.position;
        EndPointCollider.AddComponent<EndPointTrigger>();
    }

    void SetStartingCell()
    {
        int rows = gameObject.GetComponent<GameManager>().rows;        
        rowIndex = UnityEngine.Random.Range(0, rows - 1);
        colIndex = 0;
        currentCell = grid[rowIndex, colIndex].GetComponentInParent<GridCell>();
        currentCell.DestroyWall("west");
        currentCell.floor.GetComponent<Renderer>().material.color = Color.blue;
        gameObject.GetComponent<GameManager>().spawnPoint = currentCell;
    }

    void RemoveWalls(GridCell current,GridCell next) {
        int rowDiff = current.rowIndex - next.rowIndex;
        int colDiff = current.colIndex - next.colIndex;
        if (rowDiff == 1)
        {
            current.DestroyWall("north");
        }
        if (colDiff == 1)
        {
            current.DestroyWall("west");
        }
        if (rowDiff == -1)
        {
            current.DestroyWall("south");
        }
        if (colDiff == -1)
        {
            current.DestroyWall("east");
        }
    }

}
