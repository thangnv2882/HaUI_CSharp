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
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            do
            {
                Console.Write("Nhập n: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 0);

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Phần tử lớn nhất là: " + FindMax(a));
            Console.WriteLine("Phần tử nhỏ nhất là: " + FindMin(a));
            Console.WriteLine("Tổng các phần tử trong mảng là: " + Sum(a));

        }
        static int FindMax(int[] a)
        {
            int max = a[0];
            for (int i = 0; i < a.Length; i++) 
                if(max < a[i])
                    max = a[i];
            return max;
        }
        static int FindMin(int[] a)
        {
            int min = a[0];
            for (int i = 0; i < a.Length; i++)
                if (min > a[i])
                    min = a[i];
            return min;
        }

        static int Sum(int[] a)
        {
            int s = 0;
            for (int i = 0; i < a.Length; i++)
                s += a[i];
            return s;
        }
    }
}
