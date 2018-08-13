using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dis, Size size) : base(pos, dis, size) { }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);
        }

        public override void Update()
        {
            Position.X -= Direction.X;
            Position.Y += Direction.Y;
            Direction.X = (Position.X < 0 || Position.X > Game.Width) ? -Direction.X : Direction.X;
            Direction.Y = (Position.Y < 0 || Position.Y > Game.Height) ? -Direction.Y : Direction.Y;
        }
    }
}
