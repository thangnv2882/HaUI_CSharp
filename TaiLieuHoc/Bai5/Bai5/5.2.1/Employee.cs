using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2._1
{
    internal class Employee
    {
        public string id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public int workingdays { get; set; }

        private const int PRICE = 50;

        public double getSalary()
        {
            return workingdays * PRICE;
        }

        public void input()
        {
            Console.Write("Mã nhân viên: ");
            id = Console.ReadLine();

            Console.Write("Nhập tên nhân viên: ");
            name = Console.ReadLine();

            Console.Write("Nhập tuổi: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập số ngày làm việc: ");
            workingdays = Convert.ToInt32(Console.ReadLine());
        }

        public void output()
        {
            Console.WriteLine($"{id,5} {name,20} {age,15} {workingdays,20} {getSalary(),20}");
        }
    }
}
