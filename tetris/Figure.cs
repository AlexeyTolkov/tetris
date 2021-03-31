namespace tetris
{
    class Figure
    {
        protected Point[] _points;
        protected string _sym = "☺"; 

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