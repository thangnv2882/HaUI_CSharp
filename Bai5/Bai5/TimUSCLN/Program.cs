using System;
using System.Numerics;

namespace TimUSCLN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Số lượng đối tượng: ");
            int n = int.Parse(Console.ReadLine());

            TimUSCLN[] array = new TimUSCLN[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new TimUSCLN();
                Console.WriteLine("Nhập đối tượng " + (i + 1));
                array[i].Nhap();
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Thông tin đối tượng " + (i + 1));
                array[i].Xuat();
                Console.WriteLine("Ước chung lớn nhất: " + array[i].Solve(array[i].sothu1, array[i].sothu2) + "\n");
            }

            // Cách 2
            Console.WriteLine("\nHàm có sẵn.");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Thông tin đối tượng " + (i + 1));
                array[i].Xuat();
                Console.WriteLine("Ước chung lớn nhất: " + BigInteger.GreatestCommonDivisor(array[i].sothu1, array[i].sothu2));
            }
        }
    }
}
