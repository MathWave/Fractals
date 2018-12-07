namespace WindowsFormsApp1
{
    class FractalData //Класс данных фрактала
    {
        public string Name { get; } //Тип фрактала
        public int Depth { get; } //Максимальный уровень рекурсии
        public Point Center { get; set; } //Точка центра

        public FractalData(string n, int d, Point c) //Конструктор
        {
            Name = n;
            Depth = d;
            Center = c;
        }
    }
}
