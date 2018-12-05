﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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

        public virtual void Draw(Point center, ref Graphics g, List<Color> l) { }

    }
}
