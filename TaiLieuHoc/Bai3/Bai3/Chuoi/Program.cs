using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập chuỗi: ");
            string s = Console.ReadLine();
            char[] s_arr = s.ToCharArray();
            Array.Reverse(s_arr);
            string s_re = new string(s_arr);
            if (s.CompareTo(s_re) == 0)
                Console.WriteLine("Chuỗi đối xứng.");
            else
            {
                Console.WriteLine("Chuỗi không đối xứng.");
            }
        }
    }
}
