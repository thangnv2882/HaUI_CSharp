using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanBacHai
{
    internal class Program
    {
        static double a;
        static void Main(string[] args)
        {
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(can(a)); 
        }

        public static double can(double n)
        {
            if (n == 0)
                return 1;
            else
                return (a / can(n - 1) + can(n - 1)) / 2;
        }
    }
}
