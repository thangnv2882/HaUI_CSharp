using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TapTin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string path = "D:/Fighting/KyPhu4/.NET/Bai2/Bai2/taptin.txt";
            string[] a = File.ReadAllLines(path);

            Console.WriteLine("Nội dung trong file.");
            for(int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            int s = 0;
            for (int i = 2; i < a.Length; i++)
            {
                string[] nums = a[i].Split(' ');
                for (int j = 0; j < nums.Length; j++)
                    s += Convert.ToInt32(nums[j]);
            }

            string contentWrite = "Tổng các phần tử trong mảng là: " + s + "\n";
            File.AppendAllText(path, contentWrite);

        }
    }
}
