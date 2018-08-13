/*
 * Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    abstract class BaseEmployees
    {
        public abstract string PayCalc(float earnings);
        public string name;
        public string surname;
        public int age;
        public string earnings;
        public abstract string ToStr();

    }
}
