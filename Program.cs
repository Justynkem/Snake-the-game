using System;

namespace SnakeTheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            Canvas canvas = new Canvas();

            while(!finished)
            {
                canvas.drawCanvas();
                Console.Read();
            }
        }
    }
}
