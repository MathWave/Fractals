using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{

        Bitmap bmp;
        Graphics graph;
        Color defaultBG;
        Color defaultPen;
        bool isEmpty;
        Point start;
        FractalData data;
        float resize;
        bool PossibleToOverDraw;

        public Form1()
		{
            InitializeComponent();
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            defaultBG = Color.White;
            defaultPen = Color.Black;
            isEmpty = true;
            start = null;
            resize = 1;
            PossibleToOverDraw = false;
            colorDialog1.FullOpen = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(690, 520);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            graph.Clear(defaultBG);
            picture.Image = bmp;
            isEmpty = true;
            data = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            string filename = save.FileName + ".jpg";
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        void Draw()
        {
            Clear();
            string fractal_name = "";
            int depth = 0;
            bool flag = true;
            try
            {
                fractal_name = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите фрактал!", "Ошибка!");
                flag = false;
            }
            if (flag)
            {
                try
                {
                    int.TryParse(textBox1.Text, out depth);
                    if (depth < 1)
                        throw new Exception();
                }

                catch
                {
                    MessageBox.Show("Некорректный ввод глубины!", "Ошибка!");
                    flag = false;
                }
                if (flag)
                {
                    Point center = new Point(picture.Width / 2, picture.Height / 2);
                    data = new FractalData(fractal_name, depth, center);
                    _Draw();
                }

            }
        }

        void _Draw()
        {
            string fractal_name = data.Name;
            int depth = data.Depth;
            Point center = data.Center;
            if (fractal_name == "Н-фрактал")
            {
                if (depth < 8)
                    new H_Fractal(resize * 270 * (float)Math.Sqrt((float)picture.Width * (float)picture.Height / 1000 / 600), pictureBox1.BackColor, pictureBox2.BackColor, depth)
                        .Draw(center, ref graph);
                else
                    MessageBox.Show("Слишком глубокая рекурсия, не получится!\nМаксимальная возможная глубина - 7.", "Упс!");
            }
            else if (fractal_name == "С-Кривая Леви")
            {
                if (depth < 19)
                    new C_Fractal(resize * 330 * (float)Math.Sqrt((float)picture.Width * (float)picture.Height / 1000 / 600), pictureBox1.BackColor, pictureBox2.BackColor, depth)
                        .Draw(new Point(center.x, center.y + 50), ref graph);
                else
                    MessageBox.Show("Слишком глубокая рекурсия, не получится!\nМаксимальная возможная глубина - 18.", "Упс!");
            }
            else
            {
                if (depth < 8)
                    new T_Fractal(resize * 1200 * (float)Math.Sqrt((float)picture.Width * (float)picture.Height / 1000 / 600), pictureBox1.BackColor, pictureBox2.BackColor, depth)
                        .Draw(new Point(center.x, center.y + 40), ref graph);
                else
                    MessageBox.Show("Слишком глубокая рекурсия, не получится.\nМаксимальная возможная глубина - 7.", "Упс!");
            }
            picture.Image = bmp;
            isEmpty = false;
            PossibleToOverDraw = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedItem.ToString())
            {
                case "1x":
                    resize = 1;
                    break;
                case "2x":
                    resize = 2;
                    break;
                case "3x":
                    resize = 3;
                    break;
                case "5x":
                    resize = 5;
                    break;
            }
            if (!isEmpty)
                Draw();
        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            start = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (start != null && !isEmpty)
            {
                Point end = new Point(Cursor.Position.X, Cursor.Position.Y);
                float dx = end.x - start.x;
                float dy = end.y - start.y;
                data = new FractalData
                    (data.Name, data.Depth, new Point(data.Center.x + dx, data.Center.y + dy));
                graph.Clear(defaultBG);
                _Draw();
                start = null;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            picture.Width = Width - 30;
            picture.Height = Height - 120;
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            if (PossibleToOverDraw)
            {
                data.Center = new Point(picture.Width / 2, picture.Height / 2);
                _Draw();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pictureBox1.BackColor = colorDialog1.Color;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pictureBox2.BackColor = colorDialog1.Color;
        }

        List<Color> CreateColorList(Color start, Color end, int depth)
        {
            List<Color> list = new List<Color>();
            int dR = (end.R - start.R) / depth;
            int dG = (end.G - start.G) / depth;
            int dB = (end.B - start.B) / depth;
            for (int i = 0; i < depth; i++)
                list.Add(Color.FromArgb(start.R + dR * i, start.G + dG * i, start.B + dB * i));
            return list;
        }
    }
}
