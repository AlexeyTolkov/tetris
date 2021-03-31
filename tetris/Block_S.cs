namespace tetris
{
    class Block_S : Block
    {
        public Block_S(int x, int y, string sym = _sym)
        {
            _points = new Point[4];
            _points[0] = new Point(x, y, sym);
            _points[1] = new Point(x, y + 1, sym);
            _points[2] = new Point(x - 1, y + 1, sym);
            _points[3] = new Point(x + 1, y, sym);
        }
    }
}
