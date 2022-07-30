using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int choose;

            List<NhanVienBanHang> nvs = new List<NhanVienBanHang>();

            do
            {
                Console.WriteLine($"-------------------Menu--------------------");
                Console.WriteLine($"1. Nhập thông tin");
                Console.WriteLine($"2. Hiển thị danh sách");
                Console.WriteLine($"3. Hiển thị danh sách");
                Console.WriteLine($"4. Thoát");

                Console.WriteLine($"Nhập lựa chọn: ");
                choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Add(nvs);
                        break;
                    case 2:
                        Show(nvs);
                        break;
                    case 3:
                        Sort(nvs);
                        break;
                    case 4:
                        Console.WriteLine($"Kết thúc");
                        break;
                    default:
                        Console.WriteLine($"Không có lựa chọn này vui lòng nhập lại: ");
                        break;
                }
            } while (choose != 4);

        }

        static void Add(List<NhanVienBanHang> nvs)
        {
            Console.WriteLine($"1. Nhập thông tin nhân viên");
            Console.WriteLine($"2. Nhập thông tin nhân viên bán hàng");
            int c = int.Parse(Console.ReadLine());
            if (c == 1)
            {
                Console.WriteLine($"Nhập họ tên: ");
                string hoTen = Console.ReadLine();
                Console.WriteLine($"Nhập ngày tuyển dụng(ngay-thang-nam): ");
                DateTime ngayTuyenDung = DateTime.Parse(Console.ReadLine());

                NhanVienBanHang n = new NhanVienBanHang(hoTen, ngayTuyenDung, -1);
                if (IsDuplicate(nvs, n))
                {
                    Console.WriteLine($"Trùng tên nhân viên");
                    return;
                }
                nvs.Add(n);
            }
            else if (c == 2)
            {
                Console.WriteLine($"Nhập họ tên: ");
                string hoTen = Console.ReadLine();
                Console.WriteLine($"Nhập ngày tuyển dụng(ngay-thang-nam): ");
                DateTime ngayTuyenDung = DateTime.Parse(Console.ReadLine());
                Console.WriteLine($"Nhập số lượng bán: ");
                int soLuongBan = int.Parse(Console.ReadLine());

                NhanVienBanHang n = new NhanVienBanHang(hoTen, ngayTuyenDung, soLuongBan);

                if (IsDuplicate(nvs, n))
                {
                    Console.WriteLine($"Trùng tên nhân viên");
                    return;
                }
                nvs.Add(n);
            }
            else
            {
                Console.WriteLine($"Không có lựa chọn này");
            }
        }
        public static bool IsDuplicate(List<NhanVienBanHang> nvs, NhanVienBanHang nhanVien)
        {
            foreach (var item in nvs)
            {
                if (item.getHoTen().CompareTo(nhanVien.getHoTen()) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static void Show(List<NhanVienBanHang> nvs)
        {
            Console.WriteLine(String.Format("{0, -25}{1, -15}{2, -15}{3, -15}", "Họ tên", "Ngày tuyển dụng", "Số lượng bán", "Tiền hoa hồng"));

            foreach (var item in nvs)
            {
                if (item.getSoLuongBan() >= 0)
                {
                    Console.WriteLine(String.Format("{0, -25}{1, -15}{2, -15}{3, -15}", item.getHoTen(),  item.getNgayTD().ToString("dd/MM/yyyy"), item.getSoLuongBan(), item.TinhTienHoaHong()));
                }
                else
                {
                    Console.WriteLine(String.Format("{0, -25}{1, -15}{2, -15}{3, -15}", item.getHoTen(), item.getNgayTD().ToString("dd/MM/yyyy"), "-", "-"));

                }
            }
        }
        public static void Sort(List<NhanVienBanHang> nvs)
        {
            for (int i = 0; i < nvs.Count - 1; i++)
            {
                for (int j = i + 1; j < nvs.Count; j++)
                {
                    if (DateTime.Compare(nvs[i].getNgayTD(), nvs[j].getNgayTD()) > 0)
                    {
                        NhanVienBanHang n = nvs[i];
                        nvs[i] = nvs[j];
                        nvs[j] = n;
                    }
                    else if (DateTime.Compare(nvs[i].getNgayTD(), nvs[j].getNgayTD()) == 0)
                    {
                        if (String.Compare(nvs[i].getHoTen(), nvs[j].getHoTen()) > 0)
                        {
                            NhanVienBanHang n = nvs[i];
                            nvs[i] = nvs[j];
                            nvs[j] = n;
                        }
                    }
                }
            }
        }
    }
}