using System;
using System.Collections.Generic;
namespace SnakeTheGame

{
    public class Snake
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';
        char dir = 'u';

        List<Position> snakeBody;

        public int x { get; set; }
        public int y { get; set; }

        public Snake()
        {
            x = 20;
            y = 20;

            snakeBody = [new Position(x, y)];
        }

        public void drawSnake()
        {
            foreach(Position pos in snakeBody)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("█");
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
            snakeBody.RemoveAt(0);
        }
        public bool ShouldMove()
        {
            return Console.KeyAvailable;
        }
        public void snakeGrow(Position food, Food f)
        {
            Position sn = snakeBody[snakeBody.Count - 1];

            if(sn.x == food.x && sn.y == food.y)
            {
                snakeBody.Add(new Position(x, y));
                f.foodNewLocation();
            }
        }
    }
}