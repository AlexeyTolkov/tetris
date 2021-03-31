using System;
using System.Collections.Generic;

namespace tetris
{
    partial class Game
    {
        class FigureController
        {
            // initial position
            private const short _figureInitPositionX = 20;
            private const short _figureInitPositionY = 0;

            // list of figures
            private List<Figure> _figures = new List<Figure>();

            // current figure
            private Figure _figureInFocus;

            public FigureController()
            {

            }
            internal void CreateNewFigure()
            {
                _figureInFocus = new Square(_figureInitPositionX, _figureInitPositionY);
                _figures.Add(_figureInFocus);
            }

            protected void Reset()
            {
                _figures = new List<Figure>();
                _figureInFocus = null;
            }

            internal void FigureMove(Directions direction)
            { 
                if (_figureInFocus != null)
                {
                    _figureInFocus.Move(direction);
                }
            }

            internal void Draw()
            {
                _figureInFocus.Draw();
            }
        }
    }
}
