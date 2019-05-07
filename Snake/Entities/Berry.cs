using System;

namespace SnakeGame.Entities
{
    public class Berry
    {
        public Berry(GameScreen gameScreen, Random random)
        {
            this.XPosition = random.Next(1, gameScreen.Width - 2);
            this.YPosition = random.Next(1, gameScreen.Height - 2);  
        }

        public char Type { get; } = '#';
        public int XPosition { get; }
        public int YPosition { get; }
    }
}