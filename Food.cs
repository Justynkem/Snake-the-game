using System;

namespace SnakeTheGame
{
    public class Food
    {
        public int x { get; set; }
        public int y { get; set; }
        private Random rand;

        public Food()
        {
            rand = new Random();
            foodNewLocation();
        }

        public void drawFood()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("o");
        }

        public Position foodLocation()
        {
            return new Position(x, y);
        }

        public void foodNewLocation()
        {
            x = rand.Next(1, 50);
            y = rand.Next(1, 10);
        }
    }
}
