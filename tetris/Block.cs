using System;

namespace tetris
{
    abstract class Block
    {
        protected const int maxCntOfPoint = 5; 
        protected Point[] _points;
        protected const string _sym = "☺";
        protected BlockState _state = BlockState.Dropping;

        public Block(int x, int y, string sym = _sym)
        {
            _points = new Point[maxCntOfPoint - 1];
        }

        public void Draw()
        {
            foreach (var point in _points)
            {
                point.Draw();
            }
        }

        public void Hide()
        {
            foreach(var point in _points)
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

        internal void TryMove(Directions direction)
        {
            Hide();
            var clonedPoints = ClonePoints();
            Move(clonedPoints, direction);

            if (VerifyPosition(clonedPoints))
                _points = clonedPoints;

            Draw();
        }

        internal void TryRotate()
        {
            Hide();
            var clonedPoints = ClonePoints();
            Rotate(clonedPoints);

            if (VerifyPosition(clonedPoints))
                _points = clonedPoints;

            Draw();
        }

        internal void Rotate()
        {
            Rotate(_points);
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
                        pList[pointIdx] = new Point(y + offsetX, x + offsetY, _sym);
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

        bool VerifyPosition(Point[] points)
        {
            foreach (var point in points)
            {
                if (point.IsWindowBoundsCollision())
                    return false;
            }

            return true;
        }

        internal BlockState getState()
        {
            return _state;
        }

        private Point[] ClonePoints()
        {
            var newPoints = new Point[maxCntOfPoint-1];

            for (int i = 0; i < maxCntOfPoint-1; i++)
            {
                newPoints[i] = _points[i].Clone();
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