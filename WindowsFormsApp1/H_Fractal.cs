using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class H_Fractal : Fractal
    {

        public H_Fractal(float l, Color s, Color e, int d) : base(l, s, e, d) { }

        public override void Draw(Point c, ref Graphics g, Pen p, List<Color> l)
        {
            currentLevel++;
            size /= 2;
            if (currentLevel < maxLevel)
            {
                Draw(new Point(c.x - size, c.y - size), ref g, p, l);
                size *= 2;
                Draw(new Point(c.x - size, c.y + size), ref g, p, l);
                size *= 2;
                Draw(new Point(c.x + size, c.y - size), ref g, p, l);
                size *= 2;
                Draw(new Point(c.x + size, c.y + size), ref g, p, l);
                size *= 2;
            }
            currentLevel--;
            p.Color = l[this.currentLevel];
            g.DrawLine(p, c.x - size, c.y, c.x + size, c.y);
            g.DrawLine(p, c.x - size, c.y - size, c.x - size, c.y + size);
            g.DrawLine(p, c.x + size, c.y - size, c.x + size, c.y + size);
        }

    }
}
