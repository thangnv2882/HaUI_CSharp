using System;
using System.Text;

namespace _5._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Employee employee = new Employee();
            employee.input();
            Console.WriteLine($"{"Id",5} {"Name",20} {"Age",15} {"Workingdays",20} {"Salary",20}");
            employee.output();

        }
    }
}
