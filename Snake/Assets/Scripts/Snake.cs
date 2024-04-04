using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake
{
    public int SnakeLength;
    public List<Positions> SnakePositions;
    public int Id
    {
        get;
    }

    public Snake()
    {
        SnakePositions = new List<Positions>();
        Id = 1;
    }

    public void SpawnSnake()
    {
        SnakePositions.Add(new Positions(1, 5));
    }

    public List<Positions> GetPositions()
    {
        return SnakePositions;
    }
}
