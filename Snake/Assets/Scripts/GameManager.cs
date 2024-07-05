using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject Cell;
    public GameGrid grid;
    public Snake snake;
    public int Row = 15;
    public int Col = 15;
    public string lastDirection = "Right";
    private float time;
    private float updateInterval = 0.2f;

    void Start()
    {
        grid = new GameGrid(Row, Col, Cell);
        snake = new Snake();
        grid.DrawGrid();
        snake.SpawnSnake();
        SpawnApple();
    }

    public void UpdateGrid(int row, int col, int value)
    {
        grid.UpdateGrid(row, col, value);
    }

    public void ResetSnakeCells()
    {
        foreach (Positions SnakeCoordinate in snake.SnakePositions)
        {
            UpdateGrid(SnakeCoordinate.Row, SnakeCoordinate.Col, 0);
        }
    }

    public void UpdateSnakeCells()
    {
        foreach (Positions SnakeCoordinate in snake.SnakePositions)
        {
            UpdateGrid(SnakeCoordinate.Row, SnakeCoordinate.Col, snake.Id);
        }
    }

    public bool SnakeUpdate()
    {
        Positions NewHead = snake.NewHead();

        ResetSnakeCells();

        if (!CheckHead(NewHead)) {
            return false;
        };
        return true; 
    }

    public void CheckDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lastDirection == "Up" || lastDirection == "Down")
            {
                snake.Direction = "Left";
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lastDirection == "Up" || lastDirection == "Down")
            {
                snake.Direction = "Right";
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (lastDirection == "Left" || lastDirection == "Right")
            {
                snake.Direction = "Down";
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (lastDirection == "Left" || lastDirection == "Right")
            {
                snake.Direction = "Up";
            }
        }
    }

    public void SpawnApple()
    {
        int row = Random.Range(0, Row);
        int col = Random.Range(0, Col);
        if (grid.GetGridCell(row, col) == 0)
        {
            grid.UpdateGrid(row, col, 2);
        }
        else 
        {
            SpawnApple();
        }

    }

    public bool CheckHead(Positions SnakeHead)
    {
        if (!grid.WithinGrid(SnakeHead.Row, SnakeHead.Col))
        {
            GameOver();
            return false;
        }

        foreach (Positions SnakeCoordinate in snake.SnakePositions)
        {
            if (SnakeCoordinate.Row == SnakeHead.Row && SnakeCoordinate.Col == SnakeHead.Col) {
                GameOver();
                return false;
            }
        }

        int GridValue = grid.GetGridCell(SnakeHead.Row, SnakeHead.Col);

        switch (GridValue)
        {
            case 0:
                snake.UpdateSnake(SnakeHead);
                break;
            case 1:
                GameOver();
                return false;
            case 2:
                snake.AddBody(SnakeHead);
                SpawnApple();
                break;
        }

        return true; 
    }

    public void GameOver()
    {
        print("Game Over");
        this.enabled = false;
    }

    void Update()
    {
        CheckDirection();
        time += Time.deltaTime;
        grid.UpdateGridColour();
        if (time > updateInterval)
        {
            lastDirection = snake.Direction;
            SnakeUpdate();
            UpdateSnakeCells();
            time = 0f;
        }
    }
}
