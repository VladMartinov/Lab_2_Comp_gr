using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab_2_Comp.gr._
{
    public partial class Form1 : Form
    {
        // Цвет пользователя (можно будет добавить текст боксы где будут значения для r, g, b и записывать в данную переменную)
        Color usersColor = Color.FromArgb(0, 255, 0);

        public Form1()
        {
            InitializeComponent();
            // Задаем цвет заднему фону pictureBox1
            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.PowderBlue);
        }

        // метод для деления pictureBox1 визуально на 4 части
        private void print_Bg()
        {
            Graphics g = pictureBox1.CreateGraphics();

            // Очистка pictureBox1
            g.Clear(pictureBox1.BackColor);

            // Задается размер для 1/4 размера PictureBox
            SizeF smallSquareSize = new
                                    SizeF(this.pictureBox1.Width / 2,
                                    this.pictureBox1.Height / 2);
            //Создаём карандаш
            Pen myPen = new Pen(Color.FromName("Orange"), 2);
            // Цикл из 2-х итераций по оси Y
            for (int y = 0; y < 2; y++)
            {
                // 2-а шага по горизонтали по оси X
                for (int x = 0; x < 2; x++)
                {
                    // размеры квадрата
                    Rectangle rc1 = new Rectangle(x * (int)smallSquareSize.Width,
                                                    y * (int)smallSquareSize.Height,
                                                    (int)smallSquareSize.Width,
                                                    (int)smallSquareSize.Height);
                    // отображение квадрата
                    g.DrawRectangle(myPen, rc1);
                }
            }
        }

        private void buttonPixel_Click(object sender, EventArgs e)
        {
            // Вызов метода print_Bg
            print_Bg();

            Graphics g = pictureBox1.CreateGraphics();

            // в режиме Pixel
            g.PageUnit = GraphicsUnit.Pixel;

            // Степень
            float power = 5;

            // Кол-во точек на граффике
            var count = 100;

            // Шаг между точками
            var step = 0.05;

            // Запись в пременную point массива точек
            var points = Enumerable.Range(0, count) // Метод вернет массив чисел от 0 до 99
                .Select(x => step * x - step * count / 2) // пересчитаю x, получится промежуток [-5;5] с шагом 0.05
                .Select(x => new PointF((float)x, (float)Math.Pow(x, power)));  // считаем y, и формируем массив точек в декартовой системе координат

            Color myPen = usersColor; // Выбор цвета для карандаша

            var blackPen = new Pen(myPen, 1); // создание карандаша

            // Вывод на середину экрана в Pixel 
            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

            // Переворот графика
            g.ScaleTransform(1, -1);

            // приближаем изобиажение
            g.ScaleTransform(g.DpiX / 2.54f, g.DpiY / 2.54f);

            // Т.к. при приближении увеличилась и ширина карандаша то клонируем её для изменения её параметров
            var penTransform = g.Transform.Clone();

            // обращаем матрицу penTransform
            penTransform.Invert();

            // фиксируем матрицу перехода у пера, 
            // как обратную к матрице перехода e.Graphics 
            blackPen.Transform = penTransform;

            // Отображение графика
            g.DrawLines(blackPen, points.ToArray());
        }

        private void buttonMillimeter_Click(object sender, EventArgs e)
        {
            // ресуем сетку
            print_Bg();

            Graphics g = pictureBox1.CreateGraphics();

            // в режиме Millimeter
            g.PageUnit = GraphicsUnit.Millimeter;

            // Степень
            float power = 5;

            // Кол-во точек на граффике
            var count = 100;

            // Шаг между точками
            var step = 0.05f;

            // Запись в пременную point массива точек
            var points = Enumerable.Range(0, count) // Метод вернет массив чисел от 0 до 99
                .Select(x => step * x - step * count / 2) // пересчитаю x, получится промежуток [-2;2] с шагом 0.05f
                .Select(x => new PointF(x, (float)Math.Pow(x, power)));  // считаем y, и формируем массив точек в декартовой системе координат

            Color myPen = usersColor; // Выбор цвета для карандаша

            var blackPen = new Pen(myPen, 0.5f); // создание карандаша

            // Вывод на середину экрана в Millimeter
            g.TranslateTransform((0.5f * pictureBox1.Width) * (float) 0.265, (0.5f * pictureBox1.Height) * (float)0.265);

            // Переворот графика
            g.ScaleTransform(1, -1);

            // приближаем изобиажение
            g.ScaleTransform(g.DpiX / 2.54f, g.DpiY / 2.54f);

            // Т.к. при приближении увеличилась и ширина карандаша то клонируем её для изменения её параметров
            var penTransform = g.Transform.Clone();

            // обращаем матрицу penTransform
            penTransform.Invert();

            // фиксируем матрицу перехода у пера, 
            // как обратную к матрице перехода e.Graphics 
            blackPen.Transform = penTransform;

            // Отображение графика
            g.DrawLines(blackPen, points.ToArray());
        }

        private void buttonInch_Click(object sender, EventArgs e)
        {
            // ресуем сетку
            print_Bg();

            Graphics g = pictureBox1.CreateGraphics();

            // в режиме Inch
            g.PageUnit = GraphicsUnit.Inch;

            // Степень
            float power = 5;

            // Кол-во точек на граффике
            var count = 100;
            
            // Шаг между точками
            var step = 0.05f;

            // Запись в пременную point массива точек
            var points = Enumerable.Range(0, count) // Метод вернет массив чисел от 0 до 99
                .Select(x => step * x - step * count / 2) // пересчитаю x, получится промежуток [-5;5] с шагом 0.05f
                .Select(x => new PointF(x, (float)Math.Pow(x, power)));  // считаем y, и формируем массив точек в декартовой системе координат

            Color myPen = usersColor;   // Выбор цвета для карандаша

            var blackPen = new Pen(myPen, 0.01f);   // создание карандаша

            // Вывод на середину экрана в дюймах
            g.TranslateTransform((0.5f * pictureBox1.Width) / 96, (0.5f * pictureBox1.Height) / 96);

            // Переворот графика
            g.ScaleTransform(1, -1);
            
            // Отображение графика
            g.DrawLines(blackPen, points.ToArray());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            // Удаление всех рисунков
            g.Clear(pictureBox1.BackColor);
        }


    }
}
    