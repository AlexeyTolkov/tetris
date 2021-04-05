using System;
using System.Collections.Generic;
using System.Threading;

namespace tetris
{
    partial class Game
    {
        private BlocksController _figuresController;
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

            _figuresController = new BlocksController();
        }

        public void StartNewGame()
        {
            Init();
        }

        private void CreateNewFigure()
        {
            _figuresController.CreateNewFigureRandom();
        }

        public void Pause()
        {

        }

        internal void KeyPressHandler()
        {
            if (!_pressKeyHandler.OperateIfKeyPressed())
                return;

            var pressedKey = _pressKeyHandler.pressedKey;

            switch (pressedKey)
            {
                case ConsoleKey.LeftArrow:
                    _figuresController.FigureMove(Directions.Left);
                    break;
                case ConsoleKey.RightArrow:
                    _figuresController.FigureMove(Directions.Right);
                    break;
                case ConsoleKey.DownArrow:
                    _figuresController.FigureMove(Directions.Down);
                    break;
                case ConsoleKey.Spacebar:
                    _figuresController.FigureRotate();
                    break;
            }
        }

        internal void Play()
        {
            KeyPressHandler();

            _figuresController.CreateNewFigureIfNeeded();
            //_figuresController.MoveFigureDown();
            
            //Thread.Sleep(500);
        }

        private bool GameOver()
        {
            //TODO:

            // if it's impossible to create a new block because of collision


            return false;
        }
    }
}
