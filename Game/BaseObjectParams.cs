using System.Drawing;

namespace Game
{
    /// <summary>
	/// Класс параметров базового объекта
	/// </summary>
	public class BaseObjectParams
    {
        /// <summary>
        /// Положение объекта
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Дельта направления движения
        /// </summary>
        public Point Direction { get; set; }

        /// <summary>
        /// Размер объекта
        /// </summary>
        public Size Size { get; set; }
    }
}
