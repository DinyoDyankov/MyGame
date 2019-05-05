using System;
using static System.Console;

namespace Snake
{
    public class Draw 
    {
        public void Screen(int height, int width, char topAndBottomBorderSymbol, char sideBorderSymbol)
        {
            for (int i = 0; i < width; i++)
            {
                SetCursorPosition(i, 0);
                Write(topAndBottomBorderSymbol);

                SetCursorPosition(i, height - 1);
                Write(topAndBottomBorderSymbol);
            }

            for (int i = 0; i < height; i++)
            {
                SetCursorPosition(0,i);
                Write(sideBorderSymbol);

                SetCursorPosition(width - 1,i);
                Write(sideBorderSymbol);
            }
        }

        public void Berry(Berry berry)
        {
            SetCursorPosition (berry.XPosition, berry.YPosition);
            Write (berry.Type);
            SetCursorPosition (0, 0);
        }

        public void SnakeHead(Snake snake)
        {
            SetCursorPosition (snake.XPosition, snake.YPosition);
            Write(snake.Head);

            SetCursorPosition (0, 0);
        }

        public void SnakeBody(Position position)
        {
            SetCursorPosition (position.XPos, position.YPos);
            Write (position.Symbol);
            SetCursorPosition (0, 0);
        }
    }
}