using System;
namespace SnakeTheGame

{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            Canvas canvas = new Canvas();
            Snake snake = new Snake();
            Food food = new Food();

            while(!finished)
            {
                canvas.drawCanvas();
                snake.drawSnake();
                if (snake.ShouldMove())
                {
                    snake.Input();
                    food.drawFood();
                    snake.moveSnake();
                    snake.snakeGrow(food.foodLocation(), food);
                }
                Thread.Sleep(5);
            }
        }
    }
} 