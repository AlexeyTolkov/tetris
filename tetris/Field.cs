using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    static class Field
    {
        private static int _width;
        private static int _height;
        private static bool[][] _heap;

        public static int Width 
        {
            get 
            {
                return _width;
            }

            set 
            {
                _width = value;

                if (_width > 0 && _height > 0)
                { 
                    Console.SetWindowSize(_width, _height);
                    Console.SetBufferSize(_width, _height);

                    Field.HeapInitialiation();
                }
            }
        }

        public static int Height 
        { 
            get 
            {
                return _height;
            }

            set
            {
                _height = value;

                if (_width > 0 && _height > 0)
                {
                    Console.SetWindowSize(_width, _height);
                    Console.SetBufferSize(_width, _height);

                    Field.HeapInitialiation();
                }
            }
        }

        public static void HeapInitialiation()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static void AddFigure(Block block)
        {
            foreach (var p in block.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

    }
}
