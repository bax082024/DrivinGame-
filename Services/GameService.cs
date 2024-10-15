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
        obstacles.Add(new Obstacles(rand.Next(1, RoadWidht - 2), 0));
      }
    }
  }
}