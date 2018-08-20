using System;
using System.Drawing;


namespace Game
{
    class FirstAidKit : BaseObject
    {
        public FirstAidKit (Point pos, Point dis, Size size) : base(pos, dis, size) { }

        public override void Draw()
        {
            Game.buffer.Graphics.FillRectangle(Brushes.Green, Position.X, Position.Y, Size.Width, Size.Height);
            Game.buffer.Graphics.FillRectangle(Brushes.White, Position.X+Size.Width/2-3, Position.Y+5, 6, Size.Height-10);
            Game.buffer.Graphics.FillRectangle(Brushes.White, Position.X+5, Position.Y+Size.Height/2-3, Size.Width-10, 6);
        }

        public override void Update()
        {
            Position.X = Position.X - 2;
            if (Position.X <= -50)
                Position.X = 820;
        }

        public void x()
        {
            Random rnd= new Random();
            Position.X = 820;
            Position.Y = rnd.Next(5, 550);
        }

        public override void Crash() { }
    }
}
