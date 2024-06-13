 using System;
namespace SnakeTheGame

{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Canvas()
        {
            Width = Console.BufferWidth - 1;
            Height = Console.BufferHeight - 1;
            Console.CursorVisible = false;
        }

        public void drawCanvas()
        {
            Console.Clear();

            for(int i = 0; i < Width; i ++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }
            for(int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height - 1);
                Console.Write("-");
            }
            for(int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }
            for(int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Width - 1, i);
                Console.Write("|");
            }
        }

    }
}