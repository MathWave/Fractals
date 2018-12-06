namespace WindowsFormsApp1
{
    class FractalData
    {
        public string Name { get; }
        public int Depth { get; }
        public Point Center { get; set; }

        public FractalData(string n, int d, Point c)
        {
            Name = n;
            Depth = d;
            Center = c;
        }
    }
}
