namespace tetris
{
    class Square
    {
        Point[] points = new Point[4];

        public Square(int x, int y, string sym)
        {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x, y+1, sym);
            points[2] = new Point(x+1, y, sym);
            points[3] = new Point(x+1, y+1, sym);
        }

        public void Draw()
        {
            foreach (var point in points)
            {
                point.Draw();
            }
        }
    }
}
