namespace DrivinGame.Models
{
  public class Obstacle
  {
    public int X { get; set; }
    public int Y { get; set; }

    public Obstacle(int x, int y)
    {
      X = x;
      Y = y;
    }

    public void MoveDown() => Y++;
  }

}