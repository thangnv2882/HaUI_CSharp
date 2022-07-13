using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuuChuong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\nBảng cửu chương");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("\nBảng nhân " + i);
                for(int j = 1; j <=10 ; j++)
                {
                    Console.WriteLine(i + " * " + j + " = " + i * j);
                }
            }

            Console.ReadKey();
        }
    }
}
