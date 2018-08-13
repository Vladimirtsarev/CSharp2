using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    /// <summary>
    /// Игра
    /// </summary>
    static class Game
    {
        private static BufferedGraphicsContext context;
        /// <summary>
        /// Буфер кадра
        /// </summary>
        public static BufferedGraphics buffer;
        /// <summary>
		/// Свойство Ширины игрового поля
		/// </summary>
        public static int Width { get; set; }
        /// <summary>
		/// Свойство Высоты игрового поля
		/// </summary>
        public static int Height { get; set; }

        public static List<BaseObject> objs;

        private static Bullet bullet;
        private static Asteroid[] asteroids;

        /// <summary>
		/// Конструктор по умолчанию
		/// </summary>
        static Game() { }

        /// <summary>
        /// Инициализация элементов игры
        /// </summary>
        /// <param name="form">Форма в которую будет идти отрисовка игры</param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            context = BufferedGraphicsManager.Current;


            g = form.CreateGraphics();

            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            int maxWidth, minWidth, maxHeight, minHeight;
            minWidth = 0;
            maxWidth = 2000;
            minHeight = 0;
            maxHeight = 2000;

            if (Width < minWidth)
            {
                throw new ArgumentOutOfRangeException("Width", Width, "Ширина не может быть меньше " + minWidth);
            }
            if (Height < minHeight)
            {
                throw new ArgumentOutOfRangeException("Height", Height, "Высота не может быть меньше " + minHeight);
            }
            if (Width > maxWidth)
            {
                throw new ArgumentOutOfRangeException("Width", Width, "Ширина не может быть больше " + maxWidth);
            }
            if (Height > maxHeight)
            {
                throw new ArgumentOutOfRangeException("Height", Height, "Высота не может быть больше " + maxHeight);
            }

            // Загрузка объектов
            Load();
            // Связываем буфер в памяти с графическим объектом
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            // Создаём таймер
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Таймер тик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
		/// Метод отрисовки
		/// </summary>
        public static void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
            {
                obj.Draw();
            }
            bullet.Draw();
            buffer.Render();
        }

        /// <summary>
		/// Обновление элементов
		/// </summary>
        public static void Update()
        {
            BaseObject deletedObject = null;
            BaseObject movedObject = null;

            bullet.Update();
            foreach (BaseObject obj in objs)
            {
                obj.Update();
                if (obj is Asteroid)
                {
                    if (obj.Collision(bullet))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        deletedObject = obj;
                        movedObject = obj;
                        
                    }
                }
            }

            // if (movedObject != null)

            if (deletedObject != null)
            {
                var rand = new Random();
                int r = rand.Next(5, 50);
                objs.Add(new Asteroid(new Point(100, rand.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r)));
                objs.Remove(deletedObject);
                
            }
        }

        /// <summary>
		/// Метод загрузки объектов для инициализации
		/// </summary>
        public static void Load()
        {
            var rand = new Random();

            objs = new List<BaseObject>();

            for (var i = 0; i < 30; i++)
            {
                objs.Add(new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(10, 10)));
            }

            bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));

            asteroids = new Asteroid[15];

            for (var i = 0; i < 15; i++)
            {
                int r = rand.Next(5, 50);
                objs.Add(new Asteroid(new Point(100, rand.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r)));
            }



        }
    }
}
