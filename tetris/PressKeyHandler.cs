using System;

namespace tetris
{
    internal class PressKeyHandler
    {
        public ConsoleKey? PressedKey { get; private set; }

        internal bool OperateIfKeyPressed()
        {
            PressedKey = null;

            if (Console.KeyAvailable)
            {
                PressedKey = Console.ReadKey(false).Key;
            }

            return PressedKey != null;
        }

        internal bool AbortTheGame()
        {
            return PressedKey == ConsoleKey.Escape;
        }

        public PressKeyHandler()
        {
            Console.WriteLine("Press 'ESC' to stop");
        }
    }
}