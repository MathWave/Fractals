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
        public Point Center { get; set; }

        public FractalData(string n, int d, Point c)
        {
            Name = n;
            Depth = d;
            Center = c;
        }
    }
}
