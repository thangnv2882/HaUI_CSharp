using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuongThuc
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            do
            {
                Console.Write("Nhập n: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 0);

            int[] ds = new int[n];
            for (int i = 0; i < n; i++)
                ds[i] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Danh sách các số nguyên tố: ");
            nto(ds, n);
            Console.WriteLine();
        }
        static void nto(int[] ds, int n)
        {
            for (int i = 0; i < n; i++)
                if (check_nto(ds[i]) == true)
                    Console.Write(ds[i] + " ");

        }

        static Boolean check_nto(int x)
        {
            if (x < 2)
                return false;
            else
            {
                for (int i = 2; i <= Math.Sqrt(x); i++)
                    if (x % i == 0)
                        return false;
            }
            return true;
        }
    }
}
