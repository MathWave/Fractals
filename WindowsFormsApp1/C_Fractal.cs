using System;
using System.Drawing;

namespace WindowsFormsApp1
{

    public class C_Fractal : Fractal //Класс кривой Леви
    {

        public C_Fractal(float l, Color s, Color e, int d) : base(l, s, e, d) { } //Конструктор

        public override void Draw(Point center, ref Graphics g) 
        {
            _Draw(center, ref g, 2);
        }

        public void _Draw(Point center, ref Graphics g, int r) //Рисуем фрактал
        {
            currentLevel++;
            size *= (float)(Math.Sqrt(2) / 2);
            float sqrt = 0.5f;
            float half = (float)(Math.Sqrt(2) / 4);
            if (currentLevel < maxLevel) //Пока не дошли до максимальной глубины рекурсии
            {
                switch (r) //В зависимости от угла наклона формируем новые фракталы
                {
                    case 0: //correct
                        _Draw(new Point(center.x - size * half, center.y - size * half), ref g, 1);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x - size * half, center.y + size * half), ref g, 7);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 1: //correct
                        _Draw(new Point(center.x, center.y - size * sqrt), ref g, 2);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x - size * sqrt, center.y), ref g, 0);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 2: //correct
                        _Draw(new Point(center.x + size * half, center.y - size * half), ref g, 3);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x - size * half, center.y - size * half), ref g, 1);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 3: //correct
                        _Draw(new Point(center.x + size * sqrt, center.y), ref g, 4);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x, center.y - size * sqrt), ref g, 2);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 4: //correct
                        _Draw(new Point(center.x + size * half, center.y + size * half), ref g, 5);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x + size * half, center.y - size * half), ref g, 3);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 5: //correct
                        _Draw(new Point(center.x, center.y + size * sqrt), ref g, 6);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x + size * sqrt, center.y), ref g, 4);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 6: //correct
                        _Draw(new Point(center.x - size * half, center.y + size * half), ref g, 7);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x + size * half, center.y + size * half), ref g, 5);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                    case 7: //correct
                        _Draw(new Point(center.x - size * sqrt, center.y), ref g, 0);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        _Draw(new Point(center.x, center.y + size * sqrt), ref g, 6);
                        currentLevel--;
                        size *= (float)Math.Sqrt(2);
                        break;
                }
            }
            //else     //убери комментарий с else, чтобы убрать промежуточные построения
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
                Pen p = new Pen(ThisColor);
                g.DrawLine(p, first.x, first.y, second.x, second.y);
            }
        }

    }
}