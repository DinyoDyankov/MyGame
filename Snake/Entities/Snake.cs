using System.Collections.Generic;

namespace SnakeGame.Entities
{
    public class Snake
    {
        private const char HeadSymbol = '<';
        
        public Snake(GameScreen gameScreen)
        {
            this.XPosition = gameScreen.Width / 2;
            this.YPosition = gameScreen.Height / 2;
            this.Body = new List<Position>();
        }

        public char Head { get; set; } = HeadSymbol;
        public List<Position> Body { get; set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
