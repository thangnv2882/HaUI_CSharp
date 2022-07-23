using System;
using System.Collections.Generic;
using System.Text;

namespace Bai5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            List<ThiSinh> lists = new List<ThiSinh>();

            do
            {
                Console.WriteLine("\n======== MENU ========");
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
                        NhapThongTinMotThiSinh(lists);
                        break;
                    case 2:
                        showTitle();
                        lists.ForEach(ts =>
                        {
                            Console.WriteLine($"{ts.soBD,5} {ts.hoTen,20} {ts.diaChi,20} {ts.toan,10} {ts.ly,10} {ts.hoa,10} {ts.diemUuTien,15} {ts.tongDiem,10}");
                        });
                        break;
                    case 3:
                        Console.Write("Nhập điểm cần tìm kiếm: ");
                        double diem = double.Parse(Console.ReadLine());
                        showTitle();
                        findByTongDiem(lists, diem);

                        break;
                    case 4:
                        Console.Write("Nhập địa chỉ cần tìm kiếm: ");
                        string diaChi = Console.ReadLine();
                        showTitle();
                        findByDiaChi(lists, diaChi);
                        break;
                    case 5:
                        Console.Write("Nhập số báo danh cần tìm kiếm: ");
                        string soBD = Console.ReadLine();
                        findBySoBD(lists, soBD);
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

        static void NhapThongTinMotThiSinh(List<ThiSinh> lists)
        {
            ThiSinh ts = new ThiSinh();
            ts.Input();
            lists.Add(ts);
        }

        static void findByTongDiem(List<ThiSinh> lists, double diem)
        {
            lists.ForEach(ts =>
            {
                if (ts.tongDiem >= diem)
                {
                    Console.WriteLine($"{ts.soBD,5} {ts.hoTen,20} {ts.diaChi,20} {ts.toan,10} {ts.ly,10} {ts.hoa,10} {ts.diemUuTien,15} {ts.tongDiem,10}");
                }
            });
        }

        static void findByDiaChi(List<ThiSinh> lists, string diaChi)
        {
            lists.ForEach(ts =>
            {
                if (ts.diaChi.Equals(diaChi))
                {
                    Console.WriteLine($"{ts.soBD,5} {ts.hoTen,20} {ts.diaChi,20} {ts.toan,10} {ts.ly,10} {ts.hoa,10} {ts.diemUuTien,15} {ts.tongDiem,10}");
                }
            });
        }

        static void findBySoBD(List<ThiSinh> lists, string soBD)
        {
            int d = 0;
            lists.ForEach(ts =>
            {
                if (ts.soBD.Equals(soBD))
                {
                    d++;
                    ts.Output();
                }
            });
            if (d == 0)
            {
                Console.WriteLine("Không có thí sinh nào có số báo danh: " + soBD);
            }
        }


        static void showTitle()
        {
            Console.WriteLine($"{"Số BD",5} {"Họ tên",20} {"Địa chỉ",20} {"Toán",10} {"Lý",10} {"Hoá",10} {"Điểm ưu tiên",15} {"Tổng điểm",10}");
        }
    }
}
