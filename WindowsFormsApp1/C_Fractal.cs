using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public class C_Fractal : Fractal
    {

        public C_Fractal(float l, Color s, Color e, int d) : base(l, s, e, d) { }

        public override void Draw(Point center, ref Graphics g, Pen p, List<Color> l)
        {
            _Draw(center, ref g, p, 2, l);
        }

        public void _Draw(Point center, ref Graphics g, Pen p, int r, List<Color> l)
        {
            currentLevel++;
            size *= (float)(Math.Sqrt(2) / 2);
            float sqrt = 0.5f;
            float half = (float)(Math.Sqrt(2) / 4);
            if (currentLevel < maxLevel)
            {
                switch (r)
                {
                    case 0: //correct
                        _Draw(new Point(center.x - size * half, center.y - size * half), ref g, p, 1, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x - size * half, center.y + size * half), ref g, p, 7, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 1: //correct
                        _Draw(new Point(center.x, center.y - size * sqrt), ref g, p, 2, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x - size * sqrt, center.y), ref g, p, 0, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 2: //correct
                        _Draw(new Point(center.x + size * half, center.y - size * half), ref g, p, 3, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x - size * half, center.y - size * half), ref g, p, 1, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 3: //correct
                        _Draw(new Point(center.x + size * sqrt, center.y), ref g, p, 4, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x, center.y - size * sqrt), ref g, p, 2, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 4: //correct
                        _Draw(new Point(center.x + size * half, center.y + size * half), ref g, p, 5, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x + size * half, center.y - size * half), ref g, p, 3, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 5: //correct
                        _Draw(new Point(center.x, center.y + size * sqrt), ref g, p, 6, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x + size * sqrt, center.y), ref g, p, 4, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 6: //correct
                        _Draw(new Point(center.x - size * half, center.y + size * half), ref g, p, 7, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x + size * half, center.y + size * half), ref g, p, 5, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 7: //correct
                        _Draw(new Point(center.x - size * sqrt, center.y), ref g, p, 0, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x, center.y + size * sqrt), ref g, p, 6, l);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                }
            }
            //else
            {
                Point first = new Point(0, 0);
                Point second = new Point(0, 0);
                switch(r)
                {
                    case 0:
                    case 4:
                        first = new Point(center.x, center.y + size * (float)Math.Sqrt(2) * 0.5f);
                        second = new Point(center.x, center.y - size * (float)Math.Sqrt(2) * 0.5f);
                        break;
                    case 1:
                    case 5:
                        first = new Point(center.x + size * 0.5f, center.y - size * 0.5f);
                        second = new Point(center.x - size * 0.5f, center.y + size * 0.5f);
                        break;
                    case 2:
                    case 6:
                        first = new Point(center.x + size * (float)Math.Sqrt(2) * 0.5f, center.y);
                        second = new Point(center.x - size * (float)Math.Sqrt(2) * 0.5f, center.y);
                        break;
                    case 3:
                    case 7:
                        first = new Point(center.x + size * 0.5f, center.y + size * 0.5f);
                        second = new Point(center.x - size * 0.5f, center.y - size * 0.5f);
                        break;
                }
                p.Color = l[this.currentLevel - 1];
                g.DrawLine(p, first.x, first.y, second.x, second.y);
            }
        }

    }
}