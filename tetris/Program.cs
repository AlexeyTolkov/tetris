using System;

namespace tetris
{


    partial class Program
    {
        

        static void Main(string[] args)
        {
            ConsoleKey pressedKey;

            // start the game
            var game = new Game();
            game.StartNewGame();

            Console.WriteLine("Press 'ESC' to stop");
            do
            {
                pressedKey = Console.ReadKey(false).Key;

                game.KeyPressHandler(pressedKey);
                game.Proceed();

            } while (pressedKey != ConsoleKey.Escape);
        }
    }
}
