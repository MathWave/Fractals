using System.Drawing;

namespace WindowsFormsApp1
{
    public class H_Fractal : Fractal //Класс Н-фрактала
    {

        public H_Fractal(float l, Color s, Color e, int d) : base(l, s, e, d) { } //Конструктор

        public override void Draw(Point c, ref Graphics g) //рисуем фрактал
        {
            currentLevel++;
            size /= 2;
            if (currentLevel < maxLevel) //Пока не достигли максимального уровня рекурсии, рисуем фракталы
            {
                Draw(new Point(c.x - size, c.y - size), ref g);
                size *= 2;
                Draw(new Point(c.x - size, c.y + size), ref g);
                size *= 2;
                Draw(new Point(c.x + size, c.y - size), ref g);
                size *= 2;
                Draw(new Point(c.x + size, c.y + size), ref g);
                size *= 2;
            }
            currentLevel--;
            Pen p = new Pen(ThisColor);
            g.DrawLine(p, c.x - size, c.y, c.x + size, c.y);
            g.DrawLine(p, c.x - size, c.y - size, c.x - size, c.y + size);
            g.DrawLine(p, c.x + size, c.y - size, c.x + size, c.y + size);
        }

    }
}
