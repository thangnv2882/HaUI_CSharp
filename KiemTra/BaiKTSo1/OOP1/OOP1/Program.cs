using System;
using System.Collections.Generic;

namespace OOP1
{
    class Program
    {
        static List<NhanVien> nvs = new List<NhanVien>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;


            do
            {
                Console.WriteLine("=========MENU=========");
                Console.WriteLine("1. Thêm");
                Console.WriteLine("2. Hiển thị danh sách");
                Console.WriteLine("3. Sắp xếp");
                Console.WriteLine("4. Thoát");
                Console.Write("Mời bạn chọn: ");
                int choose = int.Parse(Console.ReadLine());
                switch(choose)
                {
                    case 1:
                        ThemNV();
                        break;
                    case 2:
                        HienThi();
                        break;
                    case 3:
                        Sapxep();
                        break;
                    case 4:
                        Console.WriteLine("Thoát chương trình.");
                        Environment.ExitCode = 0;
                        break;
                }
            }while(true);

        }

        static void ThemNV()
        {
            NhanVien nvNew = new NhanVien();
            nvNew.Nhap();
            for (int i = 0; i < nvs.Count; i++)
            {
                if (nvs[i].getMaNV().CompareTo(nvNew.getMaNV()) == 0)
                {
                    Console.WriteLine("Trùng mã nhân viên.");
                    return;
                }
            }
            nvs.Add(nvNew);
        }

        static void HienThi()
        {
            Console.WriteLine(String.Format("{0, -10}{1, -25}{2, -25}{3, -20}{4, -15}", "Mã NV", "Họ tên", "Địa chỉ", "Chức vụ", "Lương CB"));
            nvs.ForEach(nv =>
            {
                nv.Xuat();
            });
        }

        static void Sapxep()
        {
            for(int i = 0; i < nvs.Count; i++)
            {
                for(int j = i+1; j < nvs.Count; j++)
                {
                    if (nvs[i].TinhHeSo() > nvs[j].TinhHeSo())
                    {
                        NhanVien temp = nvs[i];
                        nvs[i] = nvs[j];
                        nvs[j] = temp;
                    }
                    else if (nvs[i].TinhHeSo() == nvs[j].TinhHeSo())
                    {
                        if (nvs[i].getLuongCB() > nvs[j].getLuongCB())
                        {
                            NhanVien temp = nvs[i];
                            nvs[i] = nvs[j];
                            nvs[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
