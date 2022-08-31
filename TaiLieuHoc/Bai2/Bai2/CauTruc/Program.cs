using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CauTruc
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            HocSinh[] hs = new HocSinh[5];
            for (int i = 0; i < hs.Length; i++)
            {
                Console.WriteLine("Nhập thông tin học sinh thứ " + i+1);
                NhapThongTinHocSinh(out hs[i]);
            }

            Console.WriteLine("Tổng tuổi của các học sinh là: " + TongTuoi(hs));
           
        }
        struct HocSinh
        {
            public string hoTen;
            public int tuoi;
            public bool gioiTinh; 
        };

        static void NhapThongTinHocSinh(out HocSinh HS)
        {
            Console.Write("Họ tên: ");
            HS.hoTen = Console.ReadLine();
            Console.Write("Tuổi: ");
            HS.tuoi = Convert.ToInt32(Console.ReadLine());
            Console.Write("Giới tính: "); 
            String gt = Console.ReadLine().Trim().ToLower();
            if (gt.CompareTo("nam") == 0)
                HS.gioiTinh = true;
            else
                HS.gioiTinh = false;
        }

        static int TongTuoi(HocSinh[] hs)
        {
            int sum = 0;
            for (int i = 0; i < hs.Length; i++)
                sum += hs[i].tuoi;
            return sum;
        }


    }
}
