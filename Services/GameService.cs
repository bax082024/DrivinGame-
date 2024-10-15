using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DrivinGame.Models;

namespace DrivinGame.Services
{
  public class GameService
  {
    private const int RoadWidht = 20;
    private const int RoadHeight = 10;
    private Car car;
    private List<Obstacle> obstacles;
    private Random rand;
    private int score = 0;

    public GameService()
    {
      car = new Car(RoadWidht / 2);
      obstacles = new List<Obstacle>();
      rand = new Random();
    }

    public void Start()
    {
      while (true)
      {
        HandleInput();
        GenerateObstacle();
        MoveObstacles();

        if (IsGameOver())
        {
          Console.Clear();
          Console.WriteLine("Game Over! Your score" + score);
          break;
        }

        Draw();
        Thread.Sleep(200);
      }
    }

    private void GenerateObstacle()
    {
      if (rand.Next(0, 5) == 0)
      {
        obstacles.Add(new Obstacle(rand.Next(1, RoadWidht - 2), 0));
      }
    }

    private void MoveObstacles()
    {
      foreach (var obstacle in obstacles)
      {
        obstacle.MoveDown();
      }

      obstacles = obstacles.Where(o => o.Y < RoadHeight).ToList();
    }

    private void HandleInput()
    {
      if (Console.KeyAvailable)
      {
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
          case ConsoleKey.LeftArrow:
          car.MoveLeft();
          break;
        }
      }
    }

    private bool IsGameOver()
    {
      return obstacles.Any(o => o.Y == RoadHeight - 1 && o.X == car.Position);
    }

    private void Draw()
    {
      Console.Clear();

      for (int y = 0; y < RoadHeight; y++)
      {
        for (int x = 0; x < RoadHeight; x++)
        {
          if (x == 0 || x == RoadHeight - 1)
          {
            Console.Write("|");
          }
          else if (y == RoadHeight - 1 && x == car.Position)
          {
            Console.Write("A");
          }
          else if (obstacles.Any(o => o.X == x && o.Y == y))
          {
            Console.Write("X");
          }
          else
          {
            Console.Write(" ");
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine("Score: " + score);
    }
  }
}