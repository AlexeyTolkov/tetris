namespace tetris
{
    class Block_T : Block
    {
        public Block_T(int x, int y, string sym = SYM)
            : base(x, y, sym)
        {
            Points[0] = new Point(x, y + 1, sym);
            Points[1] = new Point(x - 1, y, sym);
            Points[2] = new Point(x, y, sym);
            Points[3] = new Point(x + 1, y, sym);
            Draw();
        }
    }
}
