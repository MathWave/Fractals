using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class FractalData
    {
        public string Name { get; }
        public int Depth { get; }
        public List<Color> Colors { get; set; }
        public Point Center { get; set; }

        public FractalData(string n, int d, List<Color> l, Point c)
        {
            Name = n;
            Depth = d;
            Colors = l;
            Center = c;
        }
    }
}
