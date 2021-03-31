namespace tetris
{
    class Block_I : Block
    {
        public Block_I(int x, int y, string sym = _sym)
        {
            _points = new Point[4];
            _points[0] = new Point(x,y,sym);
            _points[1] = new Point(x,y+1,sym);
            _points[2] = new Point(x,y+2,sym);
            _points[3] = new Point(x,y+3,sym);
        }
    }
}