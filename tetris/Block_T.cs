namespace tetris
{
    class Block_T : Block
    {
        public Block_T(int x, int y, string sym = _sym)
            : base(x, y, sym)
        {
            _points[0] = new Point(x, y + 1, sym);
            _points[1] = new Point(x - 1, y, sym);
            _points[2] = new Point(x, y, sym);
            _points[3] = new Point(x + 1, y, sym);
            Draw();
        }
    }
}
