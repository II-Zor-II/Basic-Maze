using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridUtility{
    
    public static void DestroyWall(GameObject[,] grid, int row, int col, string direction)
    {
        if (grid != null) {
           grid[row, col].GetComponent<GridCell>().DestroyWall(direction);
        }
    }


    public static void SetRowsAndColProperty(GameObject[,] grid) {

    }


    public static void SetUndefinedWalls(GameObject[,] grid)
    {
        if(grid != null)
        {
            int rows = grid.GetLength(0);
            int col = grid.GetLength(1);
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < col; j++) {

                    if (i != rows - 1)
                    {
                        grid[i, j].GetComponentInParent<GridCell>().southWall = grid[i + 1, j].GetComponentInParent<GridCell>().northWall;
                    }
                    if (j != col - 1)
                    {
                        grid[i, j].GetComponentInParent<GridCell>().eastWall = grid[i, j + 1].GetComponentInParent<GridCell>().westWall;
                    }
                }
            }
        }
    }

    public static List<GridCell> GetUnvisitedCellNeighbors(GameObject[,] grid, int rowIndex, int colIndex)
    {
        List<GridCell> neighborList = new List<GridCell>();
        if (grid != null) {
            int rows = grid.GetLength(0);
            int col = grid.GetLength(1);

            // Edge case, check top only if cell is not on top row
            if(rowIndex != 0)
            {
                if (!grid[rowIndex-1, colIndex].GetComponentInParent<GridCell>().visited)
                {
                    neighborList.Add(grid[rowIndex - 1, colIndex].GetComponentInParent<GridCell>());
                    neighborList[neighborList.Count - 1].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.green;

                }
                else
                {
                    grid[rowIndex - 1, colIndex].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.clear;
                }
            }

            //Edge case, check left only if cell is not on left-edge column
            if (colIndex != 0)
            {
                if (!grid[rowIndex, colIndex - 1].GetComponentInParent<GridCell>().visited)
                {
                    neighborList.Add(grid[rowIndex, colIndex - 1].GetComponentInParent<GridCell>());
                    neighborList[neighborList.Count-1].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.green;

                }
                else
                {
                    grid[rowIndex, colIndex - 1].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.clear;
                }
            }


            //Edge case, check bottom only if cell is not on bottom
            if (rowIndex != rows - 1)
            {
                if (!grid[rowIndex + 1, colIndex].GetComponentInParent<GridCell>().visited)
                {
                    neighborList.Add(grid[rowIndex + 1, colIndex].GetComponentInParent<GridCell>());
                    neighborList[neighborList.Count - 1].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.green;

                }
                else
                {
                    grid[rowIndex + 1, colIndex].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.clear;
                }
            }

            //Edge Case, check irght only if cell is not on right-edge
            if (colIndex != col - 1)
            {
                if (!grid[rowIndex, colIndex+1].GetComponentInParent<GridCell>().visited)
                {
                    neighborList.Add(grid[rowIndex, colIndex + 1].GetComponentInParent<GridCell>());
                    neighborList[neighborList.Count - 1].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.green;

                }
                else
                {
                    grid[rowIndex, colIndex+1].GetComponentInParent<GridCell>().floor.GetComponent<Renderer>().material.color = Color.clear;
                }
            }
        }
        return neighborList;
    }

}
