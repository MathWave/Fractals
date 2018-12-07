namespace WindowsFormsApp1
{
    public class Point //Класс ночки в координатах float
    {
        public float x { get; } //Поле Х
        public float y { get; } //Поле У

        public Point(float x, float y) //Конструктор
        {
            this.x = x;
            this.y = y;
        }
    }
}
