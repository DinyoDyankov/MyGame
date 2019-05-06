using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        private const char headSymbol = '<';

        public Snake(GameScreen gameScreen)
        {
            this.XPosition = gameScreen.Width / 2;
            this.YPosition = gameScreen.Height / 2;
            this.Body = new List<Position>();
        }

        public char Head { get; internal set; } = headSymbol;
        public List<Position> Body { get; internal set; }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
