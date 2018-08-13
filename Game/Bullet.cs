using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Orange, Position.X, Position.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Position.X = Position.X + 2;
        }

        public override void Crash()
        { }
    }
}
