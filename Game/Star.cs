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
        public Star(Point pos, Point dis, Size size) : base( pos, dis, size) { }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.Cyan, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
            Game.buffer.Graphics.DrawLine(Pens.Cyan, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);
            Game.buffer.Graphics.DrawLine(Pens.LightCyan, Position.X, Position.Y + Size.Height / 2, Position.X + Size.Width, Position.Y + Size.Height/2);
            Game.buffer.Graphics.DrawLine(Pens.LightCyan, Position.X + Size.Width/2, Position.Y, Position.X + Size.Width / 2, Position.Y + Size.Height);
        }

        public override void Update()
        {
            Position.X += Direction.X;
            if (Position.X < -Size.Width)
            {
                Random rnd = new Random(Position.Y);
                Position.X = Game.Width + Size.Width;
                Position.Y = (rnd.Next() % (Game.Height - 120)) + 60;
                Direction.X = -4 * ((rnd.Next() % 10) + 5);
                
            }
            //Position.X -= Direction.X;
            //Position.Y += Direction.Y;
            //Direction.X = (Position.X < 0 || Position.X > Game.Width) ? -Direction.X : Direction.X;
            //Direction.Y = (Position.Y < 0 || Position.Y > Game.Height) ? -Direction.Y : Direction.Y;
        }
        public override void Crash()
        { }
    }
}
