using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.White, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;
            Direction.X = (Position.X < 0 || Position.X > Game.Width) ? -Direction.X : Direction.X;
            Direction.Y = (Position.Y < 0 || Position.Y > Game.Height) ? -Direction.Y : Direction.Y;
        }

    }
}
