using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Sym { get; set; }

        public Point(int x, int y, string sym)
        {
            X = x;
            Y = y;
            Sym = sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        internal void Move(Directions dir)
        {
            switch (dir)
            {
                case Directions.Left:
                    X--;
                    break;

                case Directions.Right:
                    X++;
                    break;

                case Directions.Down:
                    Y++;
                    break;
            }
        }

        internal Point Clone()
        {
            return new Point(X, Y, Sym);
        }
    }
}
