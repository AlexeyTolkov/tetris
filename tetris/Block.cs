using System;

namespace tetris
{
    abstract class Block
    {
        public Point[] Points;
        protected const string SYM = "☺";
        //protected BlockState State = BlockState.Dropping;
        public BlockState State { get; set; }

        protected const int MAX_CNT_OF_POINTS = 5; 

        public Block(int x, int y, string sym = SYM)
        {
            Points = new Point[MAX_CNT_OF_POINTS - 1];
            State  = BlockState.NewBlock;
        }

        public void Draw()
        {
            foreach (var point in Points)
            {
                point.Draw();
            }
        }

        public void Hide()
        {
            foreach(var point in Points)
            {
                point.Hide();
            }
        }

        public void Move(Point[] pList, Directions dir)
        {
            foreach (var p in pList)
            {
                p.Move(dir);
            }
        }

        internal PositionResult TryMove(Directions direction)
        {
            Hide();
            var clonedPoints = ClonePoints();
            Move(clonedPoints, direction);


            var result = VerifyPosition(clonedPoints);
            if (result == PositionResult.SUCCESS)
            {
                State = BlockState.Dropping;
                Points = clonedPoints;
            }

            Draw();

            return result;
        }

        internal PositionResult TryRotate()
        {
            Hide();
            var clonedPoints = ClonePoints();
            Rotate(clonedPoints);

            var result = VerifyPosition(clonedPoints);
            if (result == PositionResult.SUCCESS)
            {
                State = BlockState.Dropping;
                Points = clonedPoints;
            }

            Draw();

            return result;
        }

        internal void Rotate()
        {
            Rotate(Points);
        }

        internal void Rotate(Point[] pList)
        {
            //TODO
            int xIdx = 5;
            int yIdx = 5;

            int[,] rotateGrid = new int[xIdx, yIdx];

            // find Min X, Min Y
            int minX = int.MaxValue;
            int minY = int.MaxValue;

            foreach (var point in pList)
            {
                if (point.X < minX)
                    minX = point.X;

                if (point.Y < minY)
                    minY = point.Y;
            }

            // fill rotateGrid with offset
            int offsetX = minX;
            int offsetY = minY;

            foreach (var point in pList)
            {
                rotateGrid[point.X - offsetX, point.Y - offsetY] = 1;
            }

            var pointIdx = 0;
            for (int x = 0; x < xIdx; x++)
            {
                for (int y= 0; y < yIdx; y++)
                {
                    if (rotateGrid[x, y] == 1)
                    {
                        pList[pointIdx] = new Point(y + offsetX, x + offsetY, SYM);
                        pointIdx++;
                    }
                }
            }
        }

        //internal void TryRotate()
        //{
        //    Hide();
        //    var clonedPoints = ClonePoints();
        //    Move(clonedPoints, direction);

        //    if (VerifyPosition(clonedPoints))
        //        _points = clonedPoints;

        //    Draw();
        //}

        PositionResult VerifyPosition(Point[] points)
        {
            foreach (var point in points)
            {
                if (point.Y >= Field.Height)
                    return PositionResult.DOWN_BORDER_STRIKE;

                if (point.X >= Field.Width || point.X < 0 || point.Y < 0)
                    return PositionResult.BORDER_STRIKE;

                if (Field.CheckStrike(point))
                {
                    if (State == BlockState.NewBlock)
                    {
                        return PositionResult.NEW_BLOCK_IS_STUCKED;
                    }
                    else
                    {
                        return PositionResult.HEAP_STRIKE;
                    }
                }
            }

            return PositionResult.SUCCESS;
        }

        public PositionResult VerifyPosition()
        {
            return VerifyPosition(Points);
        }

        private Point[] ClonePoints()
        {
            var newPoints = new Point[MAX_CNT_OF_POINTS-1];

            for (int i = 0; i < MAX_CNT_OF_POINTS-1; i++)
            {
                newPoints[i] = Points[i].Clone();
            }            

            return newPoints;
        }

        public static Block Create(BlockType blockType, int x, int y)
        {
            switch (blockType)
            {
                case BlockType.I_Block:
                    return new Block_I(x, y);
                case BlockType.J_Block:
                    return new Block_J(x, y);
                case BlockType.L_Block:
                    return new Block_L(x, y);
                case BlockType.O_Block:
                    return new Block_O(x, y);
                case BlockType.S_Block:
                    return new Block_S(x, y);
                case BlockType.T_Block:
                    return new Block_T(x, y);
                case BlockType.Z_Block:
                    return new Block_Z(x, y);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}