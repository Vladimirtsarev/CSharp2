using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class EmployeeHourlyPay : BaseEmployees 
    {
        /* Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовую ставку»    */

        public EmployeeHourlyPay(string name, string surname, int age, float earnings)
        {
            base.name = name;
            base.surname = surname;
            base.age = age;
            base.earnings = PayCalc(earnings);
        }

        public override string PayCalc(float earnings)
        {
            float x = earnings * 8 * 20.8f;
            return "20.8 * 8 * почасовую ставку = "+x;
        }

        public override string ToStr()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.name + " ");
            sb.Append(base.surname + ", ");
            sb.Append(base.age + " - ");
            sb.Append(base.earnings);
            return sb.ToString();
        }
    }
}
