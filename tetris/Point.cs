using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    public class Point
    {
        int _x;
        int _y;
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

        internal void Hide()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(" ");
        }

        internal void Move(Directions dir)
        {
            switch (dir)
            {
                case Directions.Left:
                    _x--;
                    break;

                case Directions.Right:
                    _x++;
                    break;

                case Directions.Down:
                    _y++;
                    break;
            }
        }
    }
}
