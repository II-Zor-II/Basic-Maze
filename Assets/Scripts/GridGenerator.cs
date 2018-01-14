using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    protected GameObject cell;

    public GameObject[,] grid = null;

    public GameObject[,] Generate(int rows,int col)
    {
        grid = new GameObject[rows, col];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < col; j++) {
                cell = new GameObject("cell[row]: " + i + "|[col]: " + j);
                cell.AddComponent<GridCell>();
                cell.GetComponent<GridCell>().rowIndex = i;
                cell.GetComponent<GridCell>().colIndex = j;
                if (i == rows-1) {
                    //Debug.Log("Call Grid Cell Function");
                    cell.GetComponent<GridCell>().AddSouthWall();
                }
                if (j == col - 1) {
                    cell.GetComponent<GridCell>().AddEastWall();
                }
                grid[i, j] = cell;
                grid[i, j].transform.position = new Vector3(i,0,j);
            }
        }
        GridUtility.SetUndefinedWalls(grid);
        return grid;
    }
    


}
