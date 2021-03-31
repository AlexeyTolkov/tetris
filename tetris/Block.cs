namespace tetris
{
    abstract class Block
    {
        protected Point[] _points;
        protected const string _sym = "☺"; 

        public void Draw()
        {
            foreach (var point in _points)
            {
                point.Draw();
            }
        }

        public  void Move(Directions dir)
        {
            foreach (var point in _points)
            {
                point.Hide();
                point.Move(dir);
            }
        }
    }
}