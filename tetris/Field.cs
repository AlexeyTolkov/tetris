using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    static class Field
    {
        private static int _width;
        private static int _height;

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
                }
            }
        }
    }
}
