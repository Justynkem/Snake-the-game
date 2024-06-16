using System;
namespace SnakeTheGame
{
    public class SnakeIsDead: ApplicationException
    {
        public SnakeIsDead(string message): base(message)
        {
            
        }
    }
}
