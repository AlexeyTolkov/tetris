using System;
using System.Collections.Generic;
using System.Threading;

namespace tetris
{
    partial class Game
    {
        private BlocksController _blockController;
        private PressKeyHandler _pressKeyHandler;

        public Game(PressKeyHandler pressKeyHandler)
        {
            _pressKeyHandler = pressKeyHandler;
        }

        internal bool SholdBeContinued()
        {
            return !(GameOver() || _pressKeyHandler.AbortTheGame());
        }

        protected void Init()
        {
            Field.Width = 40;
            Field.Height = 30;

            Console.CursorVisible = false;

            _blockController = new BlocksController();
        }

        public void StartNewGame()
        {
            Init();
        }

        private void CreateNewFigure()
        {
            _blockController.CreateNewFigureRandom();
        }

        public void Pause()
        {

        }

        internal void KeyPressHandler()
        {
            if (!_pressKeyHandler.OperateIfKeyPressed())
                return;

            var pressedKey = _pressKeyHandler.PressedKey;

            switch (pressedKey)
            {
                case ConsoleKey.LeftArrow:
                    _blockController.FigureMove(Directions.Left);
                    break;
                case ConsoleKey.RightArrow:
                    _blockController.FigureMove(Directions.Right);
                    break;
                case ConsoleKey.DownArrow:
                    _blockController.FigureMove(Directions.Down);
                    break;
                case ConsoleKey.Spacebar:
                    _blockController.FigureRotate();
                    break;
            }
        }

        internal void Play()
        {
            KeyPressHandler();

            _blockController.CreateNewFigureIfPossible();
            //_figuresController.MoveFigureDown();
            
            //Thread.Sleep(500);
        }

        private bool GameOver()
        {
            // if it's impossible to create a new block because of collision
            return _blockController.IsGameOver();
        }
    }
}
