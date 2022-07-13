using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Double> list = new List<Double>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Nhập phần tử thứ " + (i + 1) + ": ");
                list.Add(Convert.ToDouble(Console.ReadLine()));    
            }
            Console.Write("\nDanh sách vừa nhập: ");
            Show(list);


            // sắp xếp tăng dần
            list.Sort();
            Console.Write("\nDanh sách tăng dần: ");
            Show(list);


            // xoá số âm
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.Remove(list[i]);
                    i--;
                }    

            }    

            Console.Write("\nDanh sách sau khi xoá số âm: ");
            Show(list);

            // thêm phần tử
            Console.Write("\nNhập phần tử cần thêm: ");
            double x = Convert.ToDouble(Console.ReadLine());
            list.Add(x);
            list.Sort();
            Console.Write("Danh sách sau khi thêm: ");
            Show(list);
        }

        static void Show(List<Double> list)
        {
            for(int i = 0; i < list.Count; i++)
                Console.Write(list[i] + " ");
        }
    }
}
