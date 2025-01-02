using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid
{
    public int Rows;
    public int Columns;
    public int[,] Grid;
    public GameObject GridCell;
    public Renderer[,] VisualGrid;

    public GameGrid(int rows, int cols, GameObject cell)
    {
        Rows = rows;
        Columns = cols;
        Grid = new int[Rows, Columns];
        GridCell = cell;
    }

    public void ResetGrid()
    {
        for (int rows = 0; rows < Rows; rows++)
        {
            for (int cols = 0; cols < Columns; cols++)
            {
                Grid[rows, cols] = 0;
            }
        }
    }

    public void DrawGrid()
    {
        VisualGrid = new Renderer[Rows, Columns];

        for (int rows = 0; rows < Rows; rows++)
        {
            for (int cols = 0; cols < Columns; cols++)
            {
                GameObject Cell = Object.Instantiate(GridCell, new Vector2(rows, cols), Quaternion.identity);
                Renderer CellObject = Cell.GetComponent<Renderer>();
                CellObject.sortingOrder = 1;
                VisualGrid[rows, cols] = CellObject;
            }
        }
    }

    public void UpdateGridColour()
    {
        for (int rows = 0; rows < Rows; rows++)
        {
            for (int cols = 0; cols < Columns; cols++)
            {
                Renderer Cell = VisualGrid[rows, cols];

                switch (Grid[rows, cols])
                {
                    case 0:
                        if ((rows + cols) % 2 == 0)
                        {
                            Cell.material.color = new Color32(104, 207, 67, 255);
                        } else {
                            Cell.material.color = new Color32(91, 168, 58, 255);
                        }
                        break;

                    case 1:
                        Cell.material.color = new Color32(51, 72, 227, 255);
                        break;

                    case 2:
                        Cell.material.color = new Color32(255, 0, 0, 255);
                        break;
                }
            }
        }
    }

    public int GetGridCell(int row, int col)
    {
        return Grid[row, col];
    }

    public void UpdateGrid(int row, int col, int value)
    {
        Grid[row, col] = value;
    }

    public bool WithinGrid(int row, int col)
    {
        if (row >= 0 && row < Rows && col >= 0 && col < Columns)
        {
            return true;
        }
        return false;
    }
}
