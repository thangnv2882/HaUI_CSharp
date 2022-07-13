using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Person person = new Person();
            person.input();
            Console.WriteLine("Thông tin vừa nhập.");
            person.output();
            person.checkAge(person.age);
        }
    }
}
