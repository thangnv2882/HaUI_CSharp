using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TachDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            
            int n;
            do
            {
                Console.Write("Nhập số phần tử của dãy: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 0);

            int[] a = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Nhập phần tử thứ " + (i + 1) + ": ");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            List<int> chan = new List<int>();
            List<int> le = new List<int>();
            for(int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                    chan.Add(a[i]);
                else 
                    le.Add(a[i]);
            }

            Console.Write("Dãy chẵn: ");
            chan.ForEach(i => Console.Write(i + " "));
            Console.Write("\nDãy lẻ: ");
            le.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();

        }
    }
}
