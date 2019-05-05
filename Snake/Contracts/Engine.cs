using System;
using System.Diagnostics;

namespace Snake.Contracts
{
    public class Engine : IEngine
    {
        public void Run()
        {
            var gameOver = false;

            var random = new Random();

            var score = 0;

            var currentMovement = Direction.Left;

            var gameScreen = new GameScreen();

            var draw = new Draw();
            
            var berry = new Berry(gameScreen, random);

            var snake = new Snake(gameScreen);

            while (true)
            {
                Console.Clear();

                if (snake.XPosition == gameScreen.Width - 1 || snake.XPosition == 0 ||
                    snake.YPosition == gameScreen.Height - 1 || snake.YPosition == 0)
                {
                    gameOver = true;
                };

                if (berry.XPosition == snake.XPosition && berry.YPosition == snake.YPosition) // this moves the position of the berry when eaten by snake
                {
                    score += 10;
                    berry = new Berry(gameScreen, random);
                }

                draw.Screen(gameScreen.Height,gameScreen.Width, gameScreen.TopAndBottomBorder, gameScreen.SideBorder);

                for (int i = 0; i < snake.Body.Count; i++)
                {
                    draw.SnakeBody(snake.Body[i]);
                    if (snake.Body[i].XPos == snake.XPosition && snake.Body[i].YPos == snake.YPosition)
                    {
                        gameOver = true;
                    };
                }

                if (gameOver)
                {
                    break;
                }

                draw.SnakeHead(snake);
                draw.Berry(berry);

                var timer = Stopwatch.StartNew();
                while (timer.ElapsedMilliseconds <= 100)
                {
                    currentMovement = Movement(currentMovement);
                }
                
                snake.Body.Add(new Position(snake.XPosition, snake.YPosition, '#'));

                switch (currentMovement)
                {
                    case Direction.Up:
                        snake.YPosition--;
                        snake.Head = '^';
                        break;
                    case Direction.Down:
                        snake.YPosition++;
                        snake.Head = 'v';
                        break;
                    case Direction.Left:
                        snake.XPosition--;
                        snake.Head = '<';
                        break;
                    case Direction.Right:
                        snake.XPosition++;
                        snake.Head = '>';
                        break;
                }

                if (snake.Body.Count * 10 > score)
                {
                    snake.Body.RemoveAt (0);
                }
            }

            Console.SetCursorPosition(gameScreen.Width / 5, gameScreen.Height / 2);
            Console.WriteLine("Game is over");
            Console.SetCursorPosition(gameScreen.Width / 5, gameScreen.Height / 2);
            Console.WriteLine($"Your score is {score}");
        }

        static Direction Movement(Direction currentMovement)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && currentMovement != Direction.Down)
                {
                    currentMovement = Direction.Up;
                }
                else if (key == ConsoleKey.DownArrow && currentMovement != Direction.Up)
                {
                    currentMovement = Direction.Down;
                }
                else if (key == ConsoleKey.RightArrow && currentMovement != Direction.Left)
                {
                    currentMovement = Direction.Right;
                }
                else if (key == ConsoleKey.LeftArrow && currentMovement != Direction.Right)
                {
                    currentMovement = Direction.Left;
                }
            }

            return currentMovement;
        }
    }
}