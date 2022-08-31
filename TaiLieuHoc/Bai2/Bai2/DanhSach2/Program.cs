using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSach2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            List<String> ThanhPho = new List<String>();

            add5(ref ThanhPho);
            Console.WriteLine("Danh sách thành phố.");
            show(ThanhPho);

            ThanhPho.Sort();
            Console.WriteLine("Danh sách thành phố sau khi sắp xếp.");
            show(ThanhPho);

            remove(ref ThanhPho, "Hà Nội");
            Console.WriteLine("Thêm 5 thành phố.");
            add5(ref ThanhPho);
            Console.WriteLine("Danh sách thành phố sau khi xoá.");
            show(ThanhPho);

        }

        static void show(List<String> ThanhPho)
        {
            ThanhPho.ForEach(tp =>
            {
                Console.WriteLine(tp);
            });
        }

        static void add5(ref List<String> ThanhPho)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Nhập tên thành phố thứ " + i + ": ");
                ThanhPho.Add(Console.ReadLine());
            }
        }

        static void remove(ref List<String> ThanhPho, String name)
        {
            for(int i = 0; i < ThanhPho.Count; i++)
                if (ThanhPho[i].CompareTo(name) == 0) 
                    ThanhPho.RemoveAt(i);
        }
    }
}
