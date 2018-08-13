using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    static class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics buffer;
        public static int Width { get; set; }
        public static int Heigth { get; set; }

        public static List<BaseObject> objs;

        private static Bullet bullet;
        private static Asteroid[] asteroids;
        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;


            g = form.CreateGraphics();

            Width = form.Width;
            Heigth = form.Height;
            Load();

            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Heigth));

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

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
                objs.Add(new Asteroid(new Point(100, rand.Next(0, Game.Heigth)), new Point(-r / 5, r), new Size(r, r)));
                objs.Remove(deletedObject);
                
            }
        }

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
                objs.Add(new Asteroid(new Point(100, rand.Next(0, Game.Heigth)), new Point(-r / 5, r), new Size(r, r)));
            }



        }
    }
}
