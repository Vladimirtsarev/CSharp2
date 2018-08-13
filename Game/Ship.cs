using System.Drawing;

namespace Game
{
    class Ship : BaseObject
    {
        public static event Message MessageDie;
        private int _energy = 100;
        public int Energy => _energy;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Рисуем корабль
        /// </summary>
        public override void Draw()
        {

            Game.buffer.Graphics.FillRectangle(Brushes.Wheat, Position.X, Position.Y, Size.Width, Size.Height);
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, Position.X + Size.Width / 2, Position.Y, Size.Width, Size.Height);
            Game.buffer.Graphics.DrawString(Energy.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Green, Position.X + Size.Width / 2 - 10, Position.Y+3);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Position.Y > 0) Position.Y = Position.Y - Direction.Y;
        }
        public void Down()
        {
            if (Position.Y < Game.Height) Position.Y = Position.Y + Direction.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
        public override void Crash()
        { }
    }
}
