using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake
{
    public int SnakeLength;
    public List<Positions> SnakePositions;
    public string Direction;
    public int length;
    public int Id
    {
        get;
    }

    public Snake()
    {
        SnakePositions = new List<Positions>();
        Id = 1;
        Direction = "Right";
    }

    public void SpawnSnake()
    {
        SnakePositions.Add(new Positions(1, 5));
        length += 1;  
    }

    public void UpdateDirection(string newDirection)
    {
        switch (newDirection)
        {
            case "Up":
                if (Direction == "Left" || Direction == "Right")
                {
                    Direction = newDirection;
                }
                break;
            case "Down":
                if (Direction == "Left" || Direction == "Right")
                {
                    Direction = newDirection;
                }
                break;
            case "Left":
                if (Direction == "Up" || Direction == "Down")
                {
                    Direction = newDirection;
                }
                break;
            case "Right":
                if (Direction == "Up" || Direction == "Down")
                {
                    Direction = newDirection;
                }
                break;
        }
    }

    public void AddBody()
    {
        SnakePositions.Add(new Positions(0, 5));

        length += 1;
    }

    public Positions UpdateSnake()
    {
        Positions Head = SnakePositions[0];
        Positions NewHead = new Positions(Head.Row, Head.Col);
        switch (Direction)
        {
            case "Up":
                NewHead.Col += 1;
                break;
            case "Down":
                NewHead.Col -= 1;
                break;
            case "Left":
                NewHead.Row -= 1;
                break;
            case "Right":
                NewHead.Row += 1;
                break;
        }

        for (int pos = length - 1; pos >= 1; pos--)
        {
            SnakePositions[pos] = SnakePositions[pos - 1];
        }

        SnakePositions[0] = NewHead;

        return NewHead;
    }
}
