/* Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(Pos, Size);
            }
        }

        public BaseObject(Point pos, Point dir, Size size)
        {

            Pos = pos;////IsInWindow(pos) ? pos : new Point(Game.Width / 2, Game.Heigth / 2);
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();
        

        private bool IsInWindow(Point pos)
        {
            return Pos.X > 0 && Pos.X < Game.Width && Pos.Y > 0 && Pos.Y < Game.Heigth;
        }

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }
}
