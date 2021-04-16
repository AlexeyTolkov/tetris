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
            private const int _figureInitPositionY = 0;

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

                OperatePositionResult(
                    _figureInFocus.VerifyPosition());
            }

            internal void CreateNewFigureIfPossible()
            {
                if (_figureInFocus == null
                    || _figureInFocus.State == BlockState.Freezed)
                {
                    CreateNewFigureRandom();
                }
            }

            internal void FigureRotate()
            {
                if (_figureInFocus != null)
                {
                    OperatePositionResult(
                        _figureInFocus.TryRotate());

                }
            }

            internal void FigureMove(Directions direction)
            { 
                if (_figureInFocus != null)
                {
                    OperatePositionResult( 
                        _figureInFocus.TryMove(direction), direction);
                }
            }

            internal void OperatePositionResult(PositionResult posResult, Directions direction = Directions.None)
            {
                switch (posResult)  
                {
                    case PositionResult.BORDER_STRIKE:
                        break;
                    case PositionResult.DOWN_BORDER_STRIKE:
                        FreezeTheBlock();
                        CreateNewFigureRandom();
                        break;
                    case PositionResult.HEAP_STRIKE:
                        if (direction == Directions.Down)
                        {
                            FreezeTheBlock();
                            CreateNewFigureRandom();
                        }
                        break;
                    case PositionResult.NEW_BLOCK_IS_STUCKED:
                        _figureInFocus.State = BlockState.Stucked;
                        break;
                    default:
                        break;
                }
            }

            internal bool IsGameOver()
            {
                return _figureInFocus.State == BlockState.Stucked;
            }

            private void FreezeTheBlock()
            {
                _figureInFocus.State = BlockState.Freezed;
                Field.AddFigure(_figureInFocus);
            }

            protected void Reset()
            {
                _figures = new List<Block>();
                _figureInFocus = null;
            }
        }
    }
}
