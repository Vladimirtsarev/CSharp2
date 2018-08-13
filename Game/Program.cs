/* 
 * 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
 * 3. Сделать так, чтобы при столкновениях пули с астероидом пуля и астероид регенерировались в разных концах экрана;
 * 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000
 * или принимает отрицательное значение, то выбросить исключение ArgumentOutOfRangeException().
 * 5. *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект
 * с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или позиция).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
