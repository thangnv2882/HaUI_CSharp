using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiThua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            do
            {
                Console.Write("Nhập số nguyên dương: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 0);

            // Đệ quy
            Console.WriteLine("Sử dụng đệ quy: {0}! = {1}", n, FactorialRecursion(n));

            // Không đệ quy
            Console.Write("Không sử dụng đệ quy: " + n + "! = ");
            FactorialNonRecursion(n);

        }

        static int FactorialRecursion(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * FactorialRecursion(n - 1);
        }

        static void FactorialNonRecursion(int n)
        {
            long factorial = 1;
            for (int i = 1; i <= n; i++)
                factorial *= i;
            Console.WriteLine(factorial);

        }
    }
}
