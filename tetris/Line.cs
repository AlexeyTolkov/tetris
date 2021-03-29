namespace tetris
{
    class Line
    {
        Point[] points = new Point[4];

        public Line(int x, int y, string sym)
        {
            points[0] = new Point(x,y,sym);
            points[1] = new Point(x,y+1,sym);
            points[2] = new Point(x,y+2,sym);
            points[3] = new Point(x,y+3,sym);
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