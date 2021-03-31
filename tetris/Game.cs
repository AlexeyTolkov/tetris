using System;
using System.Collections.Generic;
using System.Threading;

namespace tetris
{
    partial class Game
    {
        private short _speedOfUpdate;
        private FigureController _figuresController;

        protected void Init()
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);
            Console.CursorVisible = false;

            _speedOfUpdate = 300;

            _figuresController = new FigureController();
        }

        public void StartNewGame()
        {
            Init();
            CreateNewFigure();
        }

        private void CreateNewFigure()
        {
            _figuresController.CreateNewFigure();
        }

        public void Pause()
        {

        }

        internal void KeyPressHandler(ConsoleKey pressedKey)
        {
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
            }
        }

        internal void Proceed()
        {
            //Console.Clear();
            _figuresController.Draw();
            Thread.Sleep(_speedOfUpdate);
        }
    }
}
