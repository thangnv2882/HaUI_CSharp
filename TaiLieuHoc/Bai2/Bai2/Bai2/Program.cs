using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinhChuNhat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double d, r;
            Console.Write("Nhập chiều dài: ");
            d = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhập chiều rông: ");
            r = Convert.ToDouble(Console.ReadLine());

            double c, s;
            c = (d + r) * 2;
            s = d * r;

            Console.WriteLine("Chu vi hình chữ nhật là: {0}", c);
            Console.WriteLine("Diện tích hình chữ nhật là: {0}", s);

        }
    }
}
