using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class T_Fractal : Fractal //класс Треугольника Серпинского
    {

        public T_Fractal(float l, Color s, Color e, int d) : base(l, s, e, d) { } //Конструктор

        public override void Draw(Point c, ref Graphics g) //Рисуем фрактал
        {
            currentLevel++;
            size /= 2;
            if (currentLevel < maxLevel) //Пока не дошли до максимальной глубины рекурсии, рисуем фракталы
            {
                Draw(new Point(c.x, c.y - size * (float)(Math.Sqrt(3) / 6)), ref g);
                size *= 2;
                Draw(new Point(c.x - size / 4, c.y + size * (float)(Math.Sqrt(3) / 12)), ref g);
                size *= 2;
                Draw(new Point(c.x + size / 4, c.y + size * (float)(Math.Sqrt(3) / 12)), ref g);
                size *= 2;
            }
            currentLevel--;
            Pen p = new Pen(ThisColor);
            Point up = new Point(c.x, c.y - (float)(size * Math.Sqrt(3) / 3));
            Point left = new Point(c.x - size / 2, c.y + (float)(size * Math.Sqrt(3) / 6));
            Point right = new Point(c.x + size / 2, c.y + (float)(size * Math.Sqrt(3) / 6));
            g.DrawLine(p, up.x, up.y, left.x, left.y);
            g.DrawLine(p, up.x, up.y, right.x, right.y);
            g.DrawLine(p, left.x, left.y, right.x, right.y);

        }
    }
}
