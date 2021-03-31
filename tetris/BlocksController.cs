using System;
using System.Collections.Generic;

namespace tetris
{
    partial class Game
    {
        class BlocksController
        {
            // initial position
            private const short _figureInitPositionX = 20;
            private const short _figureInitPositionY = 0;

            // list of figures
            private List<Block> _figures = new List<Block>();

            // current figure
            private Block _figureInFocus;

            public BlocksController()
            {

            }

            internal void CreateNewFigureRandom()
            {
                CreateNewFigure(BlockTypeRandomizer.GetBlockType());
            }

            private void CreateNewFigure(BlockType blockType)
            {
                switch (blockType)
                {
                    case BlockType.I_Block:
                        _figureInFocus = new Block_I(_figureInitPositionX, _figureInitPositionY);
                        break;
                    case BlockType.J_Block:
                        _figureInFocus = new Block_J(_figureInitPositionX, _figureInitPositionY);
                        break;
                    case BlockType.L_Block:
                        _figureInFocus = new Block_L(_figureInitPositionX, _figureInitPositionY);
                        break;
                    case BlockType.O_Block:
                        _figureInFocus = new Block_O(_figureInitPositionX, _figureInitPositionY);
                        break;
                    case BlockType.S_Block:
                        _figureInFocus = new Block_S(_figureInitPositionX, _figureInitPositionY);
                        break;
                    case BlockType.T_Block:
                        _figureInFocus = new Block_T(_figureInitPositionX, _figureInitPositionY);
                        break;
                    case BlockType.Z_Block:
                        _figureInFocus = new Block_Z(_figureInitPositionX, _figureInitPositionY);
                        break;
                    default:
                        throw new NotImplementedException();

                }

                _figures.Add(_figureInFocus);
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
