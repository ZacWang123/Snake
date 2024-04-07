using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake
{
    public int SnakeLength;
    public List<Positions> Body;
    public Positions Head;
    public string Direction;
    public int Id
    {
        get;
    }

    public Snake()
    {
        Body = new List<Positions>();
        Id = 1;
        Direction = "Right";
    }

    public void SpawnSnake()
    {
        Head = new Positions(1, 5);
    }

    public void UpdateDirection(string newDirection)
    {
        Direction = newDirection;
    }

    public void UpdateHead()
    {
        switch (Direction)
        {
            case "Up":
                Head.Row += 0;
                Head.Col += 1;
                break;
            case "Down":
                Head.Row += 0;
                Head.Col += -1;
                break;
            case "Left":
                Head.Row += -1;
                Head.Col += 0;
                break;
            case "Right":
                Head.Row += 1;
                Head.Col += 0;
                break;
        }
            
    }
}
