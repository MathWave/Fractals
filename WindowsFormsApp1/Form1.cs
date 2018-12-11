using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{

        Bitmap bmp; //Поле битмапа
        Graphics graph; //Поле графа
        bool isEmpty; //Поле является ли битмап пустым
        Point start; //Точка начала отрисовки
        FractalData data; //Данные фрактала
        float resize; //Во сколько раз должен увеличиться фрактал
        bool PossibleToOverDraw; //Возможно ли перерисовать

        public Form1() //Конструктор
		{
            InitializeComponent();
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            isEmpty = true;
            start = null;
            resize = 1;
            PossibleToOverDraw = false;
            colorDialog1.FullOpen = true;
        }

        private void button1_Click(object sender, EventArgs e) //При нажатии на кнопку отрисовать фрактал
        {
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e) //При загрузке формы установить минимальный размер
        {
            this.MinimumSize = new Size(690, 520);
            this.MaximumSize = Screen.PrimaryScreen.Bounds.Size;
        }

        private void button2_Click(object sender, EventArgs e) //При нажатии на кнопку "Очистить" очистить
        {
            Clear();
        }

        void Clear() //Очистка полотна
        {
            graph.Clear(Color.White);
            picture.Image = bmp;
            isEmpty = true;
            data = null;
        }

        private void button3_Click(object sender, EventArgs e) //Сохранение изображения
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = save.FileName + ".jpg";
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        void Draw() //Отсрисовка фрактала
        {
            Clear(); //Сначала очищаем полотно
            string fractal_name = "";
            int depth = 0;
            bool flag = true;
            try
            {
                fractal_name = comboBox1.SelectedItem.ToString(); 
            }
            catch //Вылетает исключение если фрактал не выбран
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

                catch //Вылетает исключение если некорректно ввести глубину
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

        void _Draw() //Рисуем фрактал на основе поля с данными фрактала
        {
            string fractal_name = data.Name;
            int depth = data.Depth;
            Point center = data.Center;
            if (fractal_name == "Н-фрактал") //Рисуем Н-Фрактала
            {
                if (depth < 11)
                    new H_Fractal(resize * 270 * (float)Math.Sqrt((float)picture.Width * (float)picture.Height / 600000), 
                        pictureBox1.BackColor, pictureBox2.BackColor, depth)
                        .Draw(center, ref graph);
                else
                    MessageBox.Show("Слишком глубокая рекурсия, не получится!\nМаксимальная возможная глубина - 7.", "Упс!");
            }
            else if (fractal_name == "С-Кривая Леви") //Рисуем С-кривую Леви
            {
                if (depth < 19)
                    new C_Fractal(resize * 330 * (float)Math.Sqrt((float)picture.Width * (float)picture.Height / 600000),
                        pictureBox1.BackColor, pictureBox2.BackColor, depth)
                        .Draw(new Point(center.x, center.y + 50), ref graph, 2);
                else
                    MessageBox.Show("Слишком глубокая рекурсия, не получится!\nМаксимальная возможная глубина - 18.", "Упс!");
            }
            else //Рисуем треугольник серпинского
            {
                if (depth < 8)
                    new T_Fractal(resize * 1200 * (float)Math.Sqrt((float)picture.Width * (float)picture.Height / 600000),
                        pictureBox1.BackColor, pictureBox2.BackColor, depth)
                        .Draw(new Point(center.x, center.y + 50), ref graph);
                else
                    MessageBox.Show("Слишком глубокая рекурсия, не получится.\nМаксимальная возможная глубина - 7.", "Упс!");
            }
            picture.Image = bmp;
            isEmpty = false;
            PossibleToOverDraw = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //Меняем масштаб
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
        }

        private void picture_MouseDown(object sender, MouseEventArgs e) //Зафиксировать точку старта
        {
            start = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        private void picture_MouseUp(object sender, MouseEventArgs e) //Переместить фрактал
        {
            if (start != null && !isEmpty)
            {
                Point end = new Point(Cursor.Position.X, Cursor.Position.Y);
                float dx = end.x - start.x;
                float dy = end.y - start.y;
                data = new FractalData
                    (data.Name, data.Depth, new Point(data.Center.x + dx, data.Center.y + dy));
                graph.Clear(Color.White);
                _Draw();
                start = null;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e) //При изменении размеров формы...
        {
            try
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
            catch
            {
                
            }
        }
         
        private void pictureBox1_Click(object sender, EventArgs e) //Изменить стартовый цвет
        {
            colorDialog1.Color = pictureBox1.BackColor;
            colorDialog1.ShowDialog();
            pictureBox1.BackColor = colorDialog1.Color;
        }

        private void pictureBox2_Click(object sender, EventArgs e) //Изменить конечный цвет
        {
            colorDialog1.Color = pictureBox2.BackColor;
            colorDialog1.ShowDialog();
            pictureBox2.BackColor = colorDialog1.Color;
        }

    }
}
