using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập số phần tử của mảng: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Nhập phần tử thứ " + (i + 1) + ": ");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }

            int s = 0;
            for(int i = 0; i < n; i++)
            {
                if (a[i] % 2 != 0)
                    s += a[i];
            }
            Console.WriteLine("Tổng các phần tử lẻ trong mảng là: " + s);
        }
    }
}
