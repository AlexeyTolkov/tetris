using System;
using System.Collections.Generic;

namespace tetris
{
    partial class Game
    {
        class BlocksController
        {
            // initial position
            private const int _figureInitPositionX = 20;
            private const int _figureInitPositionY = 10;

            // list of figures
            private List<Block> _figures = new List<Block>();

            // current figure
            private Block _figureInFocus;

            internal void CreateNewFigureRandom()
            {
                //CreateNewFigure(BlockTypeRandomizer.GetBlockType());

                //TODO: for test
                CreateNewFigure(BlockType.J_Block);
            }

            private void CreateNewFigure(BlockType blockType)
            {
                _figureInFocus = Block.Create(blockType, _figureInitPositionX, _figureInitPositionY);
                _figures.Add(_figureInFocus);
            }

            internal void CreateNewFigureIfNeeded()
            {
                if (_figureInFocus == null
                    || _figureInFocus.getState() == BlockState.Freezed)
                {
                    CreateNewFigureRandom();
                }
            }

            internal void FigureRotate()
            {
                if (_figureInFocus != null)
                {
                    _figureInFocus.TryRotate();
                }
            }

            protected void Reset()
            {
                _figures = new List<Block>();
                _figureInFocus = null;
            }

            internal void FigureMove(Directions direction)
            { 
                if (_figureInFocus != null)
                {
                    _figureInFocus.TryMove(direction);
                }
            }
        }
    }
}
