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
            Game.buffer.Graphics.FillEllipse(Brushes.Gray, Position.X, Position.Y, Size.Width, Size.Height);
            Game.buffer.Graphics.DrawString(Size.Width.ToString(), 
                new Font(FontFamily.GenericSansSerif, (Size.Width/5)>8 ? Size.Width/5 : 8, FontStyle.Regular), 
                Brushes.Fuchsia, Position.X+ Size.Width/3, Position.Y + Size.Height/3);
        }

        public override void Update()
        {
            Position.X += Direction.X;
            //Position.Y += Direction.Y;
            //Direction.X = (Position.X < 0 || Position.X > Game.Width) ? - Direction.X : Direction.X;
            //Direction.Y = (Position.Y < 0 || Position.Y > Game.Height) ? -Direction.Y : Direction.Y;
            Position.X = (Position.X < -Size.Width) ? (Game.Width+Size.Width): Position.X;
            //Position.X = (Position.X > Game.Width) ? (- 20 - Position.X) : Position.X;
            Position.Y = (Position.Y < 0 ) ? (Game.Height + 20) : Position.Y;
            Position.Y = (Position.Y > Game.Height) ? (-1) : Position.Y;
        }

        public override void Crash()
        {
            if (Size.Height>5)
            Size.Height = Size.Height / 2;
            if (Size.Width > 5)
                Size.Width = Size.Width / 2;
        }

    }
}
