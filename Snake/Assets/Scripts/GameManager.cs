using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject Cell;
    public GameGrid grid;
    public Snake snake;
    public int row = 15;
    public int col = 15;
    private float time;
    private float updateInterval = 0.2f;

    void Start()
    {
        grid = new GameGrid(row, col, Cell);
        snake = new Snake();
        grid.DrawGrid();
        snake.SpawnSnake();
        SnakeUpdate();
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

    public void SnakeUpdate()
    {
        UpdateGrid(snake.Head.Row, snake.Head.Col, 0);
        snake.UpdateHead();
        UpdateGrid(snake.Head.Row, snake.Head.Col, snake.Id);
    }

    public void CheckDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            snake.UpdateDirection("Left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            snake.UpdateDirection("Right");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            snake.UpdateDirection("Down");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            snake.UpdateDirection("Up");
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        grid.UpdateGridColour();
        CheckDirection();
        if (time > updateInterval)
        {
            SnakeUpdate();
            time = 0f;
        }
    }
}
