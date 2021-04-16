namespace tetris
{
    class Block_I : Block
    {
        public Block_I(int x, int y, string sym = SYM) 
            : base(x, y, sym)
        {
            Points[0] = new Point(x,y+3,sym);
            Points[1] = new Point(x,y+2,sym);
            Points[2] = new Point(x,y+1,sym);
            Points[3] = new Point(x,y,sym);
            Draw();
        }
    }
}