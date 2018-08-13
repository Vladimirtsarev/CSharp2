/*1. 
 * Построить три класса (базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой (один из потомков)
 * и фиксированной оплатой (второй потомок).
а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы. Для «повременщиков» формула
для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовую ставку», для работников с фиксированной
оплатой «среднемесячная заработная плата = фиксированной месячной оплате». 
б) Создать на базе абстрактного класса массив сотрудников и заполнить его. 
в) *Реализовать интерфейсы для возможности сортировки массива используя Array.Sort(). 
г) **Создать класс содержащий массив сотрудников и реализовать возможность вывода данных с использованием foreach.
 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2
{
    public partial class Form1 : Form
    {
        BaseEmployees[] emplMas = new BaseEmployees[20];

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                emplMas[i] = (new EmployeeFixedPay("Василий_" + (i+1), "Пупкин_" + i+1, 30 + i, 1000 / (i+1)));

            }
            for (int i = 10; i < 20; i++)
            {
                emplMas[i] = (new EmployeeHourlyPay("Иван_" + (i+1), "Иванов_" + i+1, 30 + i, 50 / (i+1)));

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                sb.Append(emplMas[i].ToStr() + "\n");
            }
            richTextBox1.Text = sb.ToString();
            
        }
    }
}
