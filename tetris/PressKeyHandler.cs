using System;

namespace tetris
{
    internal class PressKeyHandler
    {
        public ConsoleKey? pressedKey { get; private set; }

        internal bool OperateIfKeyPressed()
        {
            pressedKey = null;

            if (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(false).Key;
            }

            return pressedKey != null;
        }

        internal bool AbortTheGame()
        {
            return pressedKey == ConsoleKey.Escape;
        }

        public PressKeyHandler()
        {
            Console.WriteLine("Press 'ESC' to stop");
        }
    }
}