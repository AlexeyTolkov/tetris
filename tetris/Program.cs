using System;

namespace tetris
{


    partial class Program
    {
        static void Main(string[] args)
        {
            // start the game
            var pressKeyHandler = new PressKeyHandler();
            var game = new Game(pressKeyHandler);
            
            game.StartNewGame();

            do
            {
                game.Play();
            } while (game.SholdBeContinued());
        }
    }
}
