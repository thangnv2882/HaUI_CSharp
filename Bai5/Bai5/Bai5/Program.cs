using System;
using System.Collections.Generic;
using System.Text;

namespace Bai5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<ThiSinh> listThiSinh = new List<ThiSinh>();

            do
            {
                Console.WriteLine("1. Nhập thông tin 1 thí sinh");
                Console.WriteLine("2. Hiển thị toàn bộ danh sách");
                Console.WriteLine("3. Hiển thị thí sinh theo điểm");
                Console.WriteLine("4. Hiển thị thí sinh theo địa chỉ");
                Console.WriteLine("5. Hiển thị thí sinh theo số báo danh");
                Console.WriteLine("6. Exit");

                Console.Write("Nhập lựa chọn: ");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        ThiSinh a = new ThiSinh();
                        a.Input();
                        listThiSinh.Add(a);
                        break;

                    case 2:
                        Console.WriteLine("\t\tTHÔNG TIN DANH SÁCH THÍ SINH");
                        showTitle();
                        foreach (ThiSinh ThiSinh in listThiSinh)
                        {
                            ThiSinh.OutputInline();
                        }
                        break;

                    case 3:
                        Console.Write("Nhập số điểm cần tìm: ");
                        double mark = double.Parse(Console.ReadLine());

                        Console.WriteLine("\t\tTHÔNG TIN DANH SÁCH THÍ SINH");
                        showTitle();
                        getThiSinhByTotalMark(listThiSinh, mark);
                        break;

                    case 4:
                        Console.Write("Nhập địa chỉ cần tìm: ");
                        string address = Console.ReadLine();

                        Console.WriteLine("\t\tTHÔNG TIN DANH SÁCH THÍ SINH");
                        showTitle();
                        getThiSinhByTotalAddress(listThiSinh, address);
                        break;

                    case 5:
                        Console.Write("Nhập số báo danh cần tìm: ");
                        string sobd = Console.ReadLine();

                        //Console.WriteLine("\t\tTHÔNG TIN DANH SÁCH THÍ SINH");
                        //showTitle();
                        getThiSinhByTotalSoBD(listThiSinh, sobd);
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }

            } while (true);
        }

        static void getThiSinhByTotalMark(List<ThiSinh> listThiSinh, double mark)
        {
            foreach (ThiSinh ThiSinh in listThiSinh)
            {
                if (ThiSinh.tongDiem >= mark)
                    ThiSinh.OutputInline();
            }
        }

        static void getThiSinhByTotalSoBD(List<ThiSinh> listThiSinh, string soBD)
        {
            foreach (ThiSinh ThiSinh in listThiSinh)
            {
                if (ThiSinh.soBD.Equals(soBD))
                    ThiSinh.Output();
            }
            Console.WriteLine("Không tồn tại thí sinh có số báo danh: " + soBD);
        }

        static void getThiSinhByTotalAddress(List<ThiSinh> listThiSinh, string address)
        {
            foreach (ThiSinh ThiSinh in listThiSinh)
            {
                if (ThiSinh.diaChi.Equals(address))
                    ThiSinh.OutputInline();
            }
        }

        static void showTitle()
        {
            Console.WriteLine("SoBD" + "\t" + "HoTen" + "\t" + "Địa chỉ" + "\t" + "Toán" + "\t" + "Lý" + "\t" + "Hóa" + "\t" + "Điểm ƯT" + "\t" + "Tổng điểm");
        }

        
    }
}
