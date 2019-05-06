using System.Text;
using static System.Console;

namespace Snake
{
    public class Draw 
    {
        public void Screen(int height, int width, string borderType)
        {
            var borderBuilder = new StringBuilder(); //using string builder to reduce flickering

            for (int i = 0; i < width; i++)
            {
                borderBuilder.Append(borderType);
            }

            SetCursorPosition(0, 0); //sets the top border of the screen
            Write(borderBuilder);

            SetCursorPosition(0, height - 1); //sets the bottom border of the screen
            Write(borderBuilder);

            borderBuilder.Clear();

            borderType = borderType.PadRight(39) + borderType;

            for (int i = 1; i < height - 1; i++)
            {
                borderBuilder.AppendLine(borderType);
            }

            SetCursorPosition(0,1); //sets the side borders of the screen
            Write(borderBuilder);
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