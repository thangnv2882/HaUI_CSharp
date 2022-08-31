using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapLieu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int n = 0;
            Console.WriteLine("Vòng lặp while");
            while(n < 1 || n > 100)
            {
                Console.Write("Nhập n: ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Vòng lặp do-while");
            do
            {
                Console.Write("Nhập n: ");
                n = Convert.ToInt32(Console.ReadLine());
            }while(n < 1 || n > 100);

        }

    }
}
