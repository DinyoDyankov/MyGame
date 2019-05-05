using Snake.Contracts;

namespace Snake
{
    public class StartUp
    {
        public static void Main()
        {
            var game = new Engine();

            game.Run();
        }
    }
}