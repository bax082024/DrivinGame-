

namespace DrivinGame.Models
{
  public class Car 
  {
    public int Position { get; set; }

    public Car(int initialPosition)
    {
      Position = initialPosition; 
    }

    public void MoveLeft() => Position = (Position > 1) ? Position - 1 : Position;

    public void MoveRight(int roadWidth) => Position = (Position < roadWidth - 2) ? Position + 1 : Position;
  }
}