namespace tetris
{
    class Block_J : Block
    {
        public Block_J(int x, int y, string sym = _sym)
            : base(x, y, sym)
        {
            _points[0] = new Point(x-1, y+2, sym);
            _points[1] = new Point(x, y+2, sym);
            _points[2] = new Point(x, y+1, sym);
            _points[3] = new Point(x, y, sym);
            Draw();
        }
    }
}
