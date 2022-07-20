using System;
using System.Text;

namespace BaiTap3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Student student = new Student();
            Console.WriteLine("Nhập vào Student: ");
            student.Input();

            Console.WriteLine("Thông tin Student vừa nhập: ");
            student.Output();
        }
    }
}
