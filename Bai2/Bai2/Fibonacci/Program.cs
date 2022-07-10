using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
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
            Console.WriteLine("Dãy fibonacci sử dụng đệ quy: ");
            for (int i = 0; i < n; i++)
                Console.WriteLine(FibonacciRecursion(i));

            // Không đệ quy
            Console.WriteLine("Dãy fibonacci không sử dụng đệ quy: ");
            for (int i = 0; i < n; i++)
                FibonacciNonRecursion(i);
        }

        static double FibonacciRecursion(int n)
        {
            if(n == 0 || n == 1)
                return n;
            else
                return FibonacciRecursion(n - 1) + FibonacciRecursion(n-2);
        }

        static void FibonacciNonRecursion(int n)
        {
            if (n == 0 || n == 1)
                Console.WriteLine(n);
            else
            {
                double f0 = 0;
                double f1 = 1;
                double fn = 1;

                for(int i = 2; i < n; i++)
                {
                    f0 = f1;
                    f1 = fn;
                    fn = f0 + f1;
                    Console.WriteLine("a " + fn);

                }
                Console.WriteLine(fn);

            }
        }


    }
}
