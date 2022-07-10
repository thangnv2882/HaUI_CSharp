using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCoSo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            char[] kytu = 
                {
                    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
                    'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
                    'U', 'V', 'X', 'Y', 'Z', 'W'
                };

            int n, heSo;
            Console.Write("Nhập số nguyên N: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập hệ cơ số cần chuyển sang: ");
            heSo = Convert.ToInt32(Console.ReadLine());

            char[] ketqua = new char[100];
            if (n == 0)
                Console.WriteLine("0");
            else
            {
                int i = 0;
                while(n != 0)
                {
                    int temp = n % heSo;
                    n /= heSo;

                    ketqua[i++] = kytu[temp];
                }
                Array.Reverse(ketqua);
                String s = new string(ketqua);
                Console.WriteLine("Số sau khi chuyển đổi là: " + s);
            }    
            


        }
    }
}
