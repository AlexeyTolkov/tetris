using System;

namespace tetris
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            var s = new Square(5, 5, "*");
            s.Draw();

            var lll = new Line(10, 5, "*");
            lll.Draw();

            Console.ReadLine();
        }
    }
}
