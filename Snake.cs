using System;
using System.Collections.Generic;
namespace SnakeTheGame

{
    public class Snake
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

         public List<Position> snakeBody{ get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int score {get; set; }

        public Snake()
        {
            x = 20;
            y = 20;
            score = 0;

            snakeBody = new List<Position> { new Position(x, y) };
        }

        public void drawSnake()
        {
            foreach(Position pos in snakeBody)

             if (pos.x >= 0 && pos.x < Console.WindowWidth && pos.y >= 0 && pos.y < Console.WindowHeight)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.Write("█");
                }
        }
        public void clearSnake()
        {
            foreach (Position pos in snakeBody)
            {
                if (pos.x >= 0 && pos.x < Console.WindowWidth && pos.y >= 0 && pos.y < Console.WindowHeight)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.Write(" ");
                }
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        private void direction()
        {
            if(key == 'w' && dir != 'd')
            {
                dir = 'u';
            }else if(key == 's' && dir != 'u')
            {
                dir = 'd';
            }else if(key == 'd' && dir != 'l')
            {
                dir = 'r';
            }else if(key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }
        public void moveSnake()
        {
            direction();
            if(dir == 'u')
            {
                y--;
            }else if(dir == 'd')
            {
                y++;
            }else if(dir == 'r')
            {
                x++;
            }else if(dir == 'l')
            {
                x--;
            }
            snakeBody.Add(new Position(x, y));
            Position tail = snakeBody[0];
            snakeBody.RemoveAt(0);
            if (tail.x >= 0 && tail.x < Console.WindowWidth && tail.y >= 0 && tail.y < Console.WindowHeight)
            {
                Console.SetCursorPosition(tail.x, tail.y);
                Console.Write(" ");
            }
        }
        public bool ShouldMove()
        {
            return Console.KeyAvailable;
        }
        public void Grow()
        {
            Position tail = snakeBody[0];
            snakeBody.Insert(0, new Position(tail.x, tail.y));
            score++;
        }
        public void isDead()
        {
            Position head = snakeBody[snakeBody.Count - 1];
            for(int i = 0; i < snakeBody.Count - 2; i++)
            {
                Position sb = snakeBody[i];

                if(head.x == sb.x && head.y == sb.y)
                {
                    throw new SnakeIsDead("YOU LOST THE GAME, TRY AGAIN");
                }

            }
        }

        public void hitWall(Canvas canvas)
        {
            Position head = snakeBody[snakeBody.Count - 1];
            if(head.x >= canvas.Width || head.x <= 0 || head.y >= canvas.Height || head.y <= 0)
            {
                throw new SnakeIsDead("YOU LOST THE GAME, TRY AGAIN");
            }   
        }
    }
}