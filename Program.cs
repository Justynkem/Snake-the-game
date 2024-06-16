using System;
using System.Threading;
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

            canvas.drawCanvas();
            snake.drawSnake();
            food.drawFood();


            while(!finished)
            {
                try
                {
                    canvas.drawCanvas();
                    
                    Console.SetCursorPosition(90, 5);
                    Console.Write("SCORE : {0}", snake.score);

                    snake.drawSnake();
                    food.drawFood();

                    if (snake.ShouldMove())
                {
                    snake.clearSnake();
                    snake.Input();
                    snake.moveSnake();
                    snake.drawSnake();
                }

                if (snake.snakeBody[snake.snakeBody.Count - 1].x == food.x &&
                    snake.snakeBody[snake.snakeBody.Count - 1].y == food.y)
                {
                    snake.Grow();
                    food.foodNewLocation();
                    food.drawFood();
                }
                snake.isDead();
                snake.hitWall(canvas);
                }
                catch(SnakeIsDead e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("RESTART THE GAME BY PRESSING ENTER");
                    char c = char.Parse(Console.ReadLine());
                    
                    switch(c)
                    {
                        case 'y':

                        snake.x = 20;
                        snake.y = 20;
                        
                        break;
                    }
                }

                Thread.Sleep(5);
            }
        }
    }
} 