using System.Drawing;

namespace WindowsFormsApp1
{
    public class Fractal //Базовые класс фрактала
    {

        protected float size; //Размер фрактала
        protected Color startColor; //Начальный цвет (задается пользователем)
        protected Color endColor; //Конечный цвет (задается пользователем)
        protected int currentLevel; //текущий уровень рекурсии
        protected int maxLevel; //максимальный уроень рекурсии

        public Fractal(float l, Color s, Color e, int d) //Конструктор
        {
            size = l;
            currentLevel = 0;
            startColor = s;
            endColor = e;
            maxLevel = d;
        }

        public virtual void Draw(Point center, ref Graphics g) { } //Метод рисования фрактала (переопределяется)

        public virtual void Draw(Point center, ref Graphics g, int r) { } //Еще один метод рисования фрактала (переопределяется)

        protected Color ThisColor //Свойство, возвращающее цвет для текущего уровня рекурсии
        {
            get
            {
                int dR = (endColor.R - startColor.R) / maxLevel;
                int dG = (endColor.G - startColor.G) / maxLevel;
                int dB = (endColor.B - startColor.B) / maxLevel;
                return Color.FromArgb(startColor.R + dR * currentLevel, startColor.G + dG * currentLevel, startColor.B + dB * currentLevel);
            }
        }
    }
}