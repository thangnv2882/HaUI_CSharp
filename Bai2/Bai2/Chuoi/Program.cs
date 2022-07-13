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
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập chuỗi: ");
            String str = Console.ReadLine();
            Console.WriteLine("\nCâu a.");
            CauA(str);
            Console.WriteLine("\nCâu b. Chuỗi sau khi chuẩn hoá: " + CauB(ref str));
            Console.WriteLine("\nCâu c. Đếm số ký tự trong một chuỗi");
            CauC(str);

        }

        static void CauA(String str)
        {
            for (int i = 0; i < str.Length; i++)
                Console.WriteLine(str[i]);
        }

        static String CauB(ref String str)
        {
            str = str.Trim();
            while (str.Contains("  "))
            {
                str = str.Remove(str.IndexOf("  "), 1);
            }
            return str;
        }

        static void CauC(String str)
        {
            while (str.Length > 0)
            {
                Console.Write(str[0] + " : ");
                int count = 0;
                for (int i = 0; i < str.Length; i++)
                    if (str[0] == str[i])
                        count++;
                Console.WriteLine(count);

                str = str.Replace(str[0].ToString(), string.Empty);
            }
        }

    }
}
