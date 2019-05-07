using System;
using System.Threading;
using SnakeGame.Core.Directions;
using SnakeGame.Entities;

namespace SnakeGame.Core.Contracts
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

            var cursorTopPosition = gameScreen.Width / 5;
            var cursorLeftPosition = gameScreen.Height / 2 - 3;

            var draw = new Draw();
            
            var berry = new Berry(gameScreen, random);

            var snake = new Snake(gameScreen);

            const int snakeSpeed = 100; //if you reduce the number the snake will go faster and if number is increased the snake will go slower
            
            while (true)
            {
                Console.Clear();

                Console.CursorVisible = false;

                draw.Screen(gameScreen.Height,gameScreen.Width, gameScreen.BorderType);

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

                Thread.Sleep(snakeSpeed);
                currentMovement = Movement(currentMovement);
                
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

            Console.SetCursorPosition(cursorTopPosition, cursorLeftPosition);
            Console.WriteLine("Game is over".PadLeft(18));
            Console.SetCursorPosition(cursorTopPosition, cursorLeftPosition + 1);
            Console.WriteLine($"Your score is {score}".PadLeft(20));
            Console.SetCursorPosition(cursorTopPosition - 5, cursorLeftPosition + 2);
            Console.WriteLine("Press any key to restart, press Esc to close.");

            while (true)
            {
                var pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else
                {
                    var game = new Engine();
                    game.Run();
                }
            }
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