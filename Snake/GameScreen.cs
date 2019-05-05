using System;

namespace Snake
{
    public class GameScreen
    {
        public int Height { get; } = 20;

        public int Width { get; } = 40;

        public char TopAndBottomBorder { get; } = '=';
        public char SideBorder { get; } = '|';
    }
}