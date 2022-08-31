using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongChuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Nhập n: ");
            n = Convert.ToInt32(Console.ReadLine());

            int s1 = 0;
            for(int i = 0; i <= n; i++)
                s1 += i;
            Console.WriteLine(s1);

            double s2 = 0;
            for (int i = 1; i <= n; i++)
                s2 += (double)1/i;
            Console.WriteLine(s2);

        }
    }
}
