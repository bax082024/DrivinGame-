using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using DrivinGame.Models;

namespace DrivinGame.Services
{
    public class GameService
    {
        private const int RoadWidth = 20; 
        private const int RoadHeight = 10;
        private Car car;
        private List<Obstacle> obstacles;
        private Random rand;
        private int score = 0;

        public GameService()
        {
            car = new Car(RoadWidth / 2); 
            obstacles = new List<Obstacle>();
            rand = new Random();
        }

        public void Start()
        {
          int speed = 200;
            while (true)
            {
                HandleInput();
                GenerateObstacle();
                MoveObstacles();

                if (IsGameOver())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! Your score: " + score); 
                    break;
                }

                Draw();

                speed = Math.Max(50, 200 - (score / 10));
                Thread.Sleep(speed);
            }
        }

        private void GenerateObstacle()
        {
            if (obstacles.Count < 10 && rand.Next(0, 5) == 0) 
            {
                obstacles.Add(new Obstacle(rand.Next(1, RoadWidth - 2), 0));
            }
        }

        private void MoveObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.MoveDown();
            }

            obstacles = obstacles.Where(o => o.Y < RoadHeight).ToList();
            score++; 
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
                    case ConsoleKey.RightArrow: 
                        car.MoveRight(RoadWidth); 
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
            var screen = new StringBuilder();

            for (int y = 0; y < RoadHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < RoadWidth; x++) 
                {
                    if (x == 0 || x == RoadWidth - 1) 
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
