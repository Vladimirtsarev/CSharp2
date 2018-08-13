/* Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class BaseObject : ICollision
    {
        protected Point Position;
        protected Point Direction;
        public Size Size;

        public delegate void Message();

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(Position, Size);
            }
        }

        /// <summary>
		/// Конструктор базового объекта
		/// </summary>
		/// <param name="prm">Параметры объекта</param>
        public BaseObject(BaseObjectParams prm)
        {
            Position = prm.Position;
            Direction = prm.Direction;
            Size = prm.Size;
        }

        /// <summary>
        /// Конструктор базового объекта
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Position = pos;  ////IsInWindow(pos) ? pos : new Point(Game.Width / 2, Game.Heigth / 2);
            Direction = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

        public abstract void Crash();

        private bool IsInWindow(Point pos)
        {
            return Position.X > 0 && Position.X < Game.Width && Position.Y > 0 && Position.Y < Game.Height;
        }

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }
}
