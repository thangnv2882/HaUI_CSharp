using System;

namespace Bai5
{
    internal class ThiSinh
    {
        public string soBD { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public double toan { get; set; }
        public double ly { get; set; }
        public double hoa { get; set; }
        public double diemUuTien { get; set; }
        public double tongDiem { get; set; }

        public void Input()
        {
            Console.Write("Nhập số báo danh: ");
            soBD = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            diaChi = Console.ReadLine();

            Console.Write("Nhập điểm toán: ");
            toan = double.Parse(Console.ReadLine());

            Console.Write("Nhập điểm ly: ");
            ly = double.Parse(Console.ReadLine());

            Console.Write("Nhập điểm hoa: ");
            hoa = double.Parse(Console.ReadLine());

            Console.Write("Nhập điểm ưu tiên: ");
            diemUuTien = double.Parse(Console.ReadLine());

            tongDiem = toan + ly + hoa + diemUuTien;
        }

        public void Output()
        {

            Console.WriteLine("Số báo danh: " + soBD);

            Console.WriteLine("Họ tên: " + hoTen);

            Console.WriteLine("Địa chỉ: "  + diaChi);

            Console.WriteLine("Điểm toán: " + toan);

            Console.WriteLine("Điểm lý: " + ly);

            Console.WriteLine("Điểm hoá: " + hoa);

            Console.WriteLine("Điểm ưu tiên: " + diemUuTien);

            Console.WriteLine("Tổng điểm: " + tongDiem);

        }

        public void OutputInline()
        {
            Console.WriteLine(soBD + "\t" + hoTen + "\t" + diaChi + "\t" + toan + "\t" + ly + "\t" + hoa + "\t" + diemUuTien + "\t" + tongDiem);

        }

    }

}
