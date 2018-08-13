using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class EmployeeFixedPay : BaseEmployees
    {
        /*Для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированной месячной оплате». */

        public EmployeeFixedPay(string name, string surname, int age, float earnings)
        {
            base.name = name;
            base.surname = surname;
            base.age = age;
            base.earnings = PayCalc(earnings);

        }

        public override string PayCalc(float earnings)
        {
            float x = earnings;
            return "Фиксированная месячная оплата = "+x;
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
