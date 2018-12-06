using System.Drawing;

namespace WindowsFormsApp1
{
    public class Fractal
    {

        protected float size;
        protected Color startColor;
        protected Color endColor;
        protected int currentLevel;
        protected int maxLevel;

        public Fractal(float l, Color s, Color e, int d)
        {
            size = l;
            currentLevel = 0;
            startColor = s;
            endColor = e;
            maxLevel = d;
        }

        public virtual void Draw(Point center, ref Graphics g) { }

        protected Color ThisColor
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