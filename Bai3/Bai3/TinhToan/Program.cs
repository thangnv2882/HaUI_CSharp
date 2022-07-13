using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhToan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Nhập số thực a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập số thực b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập phép tính: ");
            string pt = Console.ReadLine();
            tinh(a, b, pt);

        }

        static void tinh(double a, double b, string pt)
        {
            switch(pt)
            {
                case "+":
                    Console.WriteLine("{0} + {1} = {2}", a, b, a+b);
                    break;
                case "-":
                    Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
                    break;
                case "*":
                    Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
                    break;
                case "/":
                    Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
                    break;
                default:
                    Console.WriteLine("Phép tính không hợp lệ.");
                    break;
            }
        }
    }
}
