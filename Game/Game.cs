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

        // Создаём таймер
        private static Timer timer = new Timer();
        public static List<BaseObject> _objs;

        

        private static int asterCount;

        private static List<Bullet> _bullets=new List<Bullet>();
        private static Ship _ship;
        private static FirstAidKit fak;
        private static Asteroid[] _asteroids=new Asteroid[15];

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
            //Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;

            Ship.MessageDie += Finish;
            form.KeyDown += Form_KeyDown;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                System.Media.SystemSounds.Beep.Play();
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
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
            for (int i = 0; i < _asteroids.Length; i++)
                _asteroids[i]?.Draw();

            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            foreach (Bullet b in _bullets) b.Draw();
            
            //bullet?.Draw();
            _ship?.Draw();
            fak?.Draw();

            if (_ship != null)
                buffer.Graphics.DrawString("Энергия:" + _ship.Energy,
                SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Graphics.DrawString("Астероидов: " + asterCount.ToString(), SystemFonts.DefaultFont, Brushes.White, 100, 0);
            buffer.Render();
        }

        /// <summary>
		/// Обновление элементов
		/// </summary>
        public static void Update()
        {
            BaseObject deletedObject = null;
            BaseObject movedObject = null;

            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet b in _bullets) b.Update();
            //bullet?.Update();
            fak?.Update();

            asterCount = 0;
            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullets.RemoveAt(j);
                    j--;
                }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                _ship.EnergyLow(_asteroids[i].Size.Width);
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }
            //foreach (BaseObject obj in _objs)
            //{
            //    obj.Update();
            //    if (obj is Asteroid)
            //    {
            //        asterCount++;
            //        if (obj.Collision(bullet))
            //        {
            //            System.Media.SystemSounds.Beep.Play();
            //            deletedObject = obj;
            //            movedObject = obj;
                        
            //        }
            //        if (!obj.Collision(_ship)) continue;
            //        obj.Crash();
            //        Random rnd = new Random();
            //        //ship?.EnergyLow(rnd.Next(1, 10));
            //        _ship?.EnergyLow(obj.Size.Height/3);
            //        System.Media.SystemSounds.Asterisk.Play();
            //        if (_ship.Energy <= 0) _ship?.Die();

            //    }
            //}
            
            if (fak.Collision(_ship))
            {
                _ship.EnergyIncrease(50);
                fak.x();
            }

            // if (movedObject != null)

            if (deletedObject != null)
            {
                var rand = new Random();
                int r = rand.Next(5, 50);
                _objs.Add(new Asteroid(new Point(100, rand.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r)));
                _objs.Remove(deletedObject);
                
            }
        }

        /// <summary>
		/// Метод загрузки объектов для инициализации
		/// </summary>
        public static void Load()
        {
            Random rand = new Random();
            
            _objs = new List<BaseObject>();

            int starCount = 30;
            int asteroidCount = 15;


            for (int i = 0; i < starCount; i++)
            {
                _objs.Add(new Star(new Point(0, i * 20), new Point( - i, 0), new Size(5, 5)));
                Console.WriteLine("Добавлена звезда ({0},{1})",0,i*20);
            }
            

            

            _ship = new Ship(new Point(10, 190), new Point(5, 5), new Size(40, 20));
            
            _asteroids = new Asteroid[15];
            //bullet = new Bullet(new Point(50, ship.Ypos), new Point(5, 0), new Size(4, 1));

            fak = new FirstAidKit(new Point(820, rand.Next(5, 550)), new Point(-1, 0), new Size(40, 40));

            for (int i = 0; i < asteroidCount; i++)
            {
                int r = rand.Next(5, 50);
                //_objs.Add(new Asteroid(new Point(800, rand.Next(0, Game.Height)), new Point(-r / 5, r/5), new Size(r, r)));
                _asteroids[i] = new Asteroid(new Point(800, rand.Next(0, Game.Height)), new Point(-r / 5, r / 5), new Size(r, r));
            }



        }


        public static void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString("Конец игры", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 200, 80);
            buffer.Render();
        }
    }
}
