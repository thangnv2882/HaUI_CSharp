using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepLoaiHS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hoten;
            double diemthi;
            Console.Write("Nhập họ tên: ");
            hoten = Console.ReadLine();
            Console.Write("Nhập điểm thi: ");
            diemthi = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(hoten.ToUpper());
            if (diemthi >= 8)
                Console.WriteLine("Giỏi");
            else if (diemthi >= 6.5)
                Console.WriteLine("Khá");
            else if (diemthi >= 5)
                Console.WriteLine("Trung bình");
            else
                Console.WriteLine("Yếu");
        }
    }
}
