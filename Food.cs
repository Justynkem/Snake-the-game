 using System;
namespace SnakeTheGame;

public class Food
{
    public Position foodPos = new Position();
    Random rnd = new Random();
    Canvas canvas = new Canvas();
    public Food()
    {
        foodPos.x = rnd.Next(5, canvas.Width);
        foodPos.y = rnd.Next(5, canvas.Height);
    }
    public void drawFood()
    {
        Console.SetCursorPosition(foodPos.x, foodPos.y);
        Console.Write("F");
    }
    public Position foodLocation()
    {
        return foodPos;
    }
    public void foodNewLocation()
    {
        foodPos.x = rnd.Next(5, canvas.Width);
        foodPos.y = rnd.Next(5, canvas.Height);   
    }
}

