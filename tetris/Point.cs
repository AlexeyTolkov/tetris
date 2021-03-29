using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    class Point
    {
        readonly int _x;
        readonly int _y;
        readonly string _sym;

        public Point(int x, int y, string sym)
        {
            _x = x;
            _y = y;
            _sym = sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }
    }
}
