/* 
 * 1. Добавить космический корабль, как описано в уроке.
 * 2. Добработать игру «Астероиды».
 * а) Добавить ведение журнала в консоль с помощью делегатов;
 * б) *Добавить это и в файл.
 * 3. Разработать аптечки, которые добавляют энергию.
 * 4. Добавить подсчет очков за сбитые астероиды.
 * 5. *Добавить в пример Lesson3 обобщенный делегат.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    static class Program
    {
        /// <summary>
        /// Точка входа.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            Game.Draw();
            Application.Run(form);
        }
    }
}
