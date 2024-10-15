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
      
    }
  }
}