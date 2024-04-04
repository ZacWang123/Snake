using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Cell;
    public GameGrid grid;
    public Snake snake;
    public int row = 15;
    public int col = 15;

    void Start()
    {
        grid = new GameGrid(row, col, Cell);
        snake = new Snake();
        grid.DrawGrid();
        snake.SpawnSnake();
        //snakeUpdate();
    }

    public void UpdateGrid(int row, int col, int value)
    {
        grid.UpdateGrid(row, col, value);
    }


    /**
    public void snakeUpdate()
    {
        foreach (Positions SnakeCoordinate in snake.GetPositions())
        {
            UpdateGrid(SnakeCoordinate.Row, SnakeCoordinate.Col, snake.Id);
        }
    }
    **/

    void Update()
    { 
        grid.UpdateGridColour();
    }
}
