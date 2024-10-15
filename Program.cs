using DrivinGame.Services;

namespace DrivinGame
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.CursorVisible = false;
      var gameService = new GameService();
      gameService.Start();
    }
  }

}