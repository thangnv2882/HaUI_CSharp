using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class NhanVienBanHang : NhanVien
    {
        private int soLuongBan;

        public void setSoLuongBan(int soLuongBan)
        {
            this.soLuongBan = soLuongBan;
        }
        public int getSoLuongBan()
        {
            return soLuongBan;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Số lượng bán: ");
            soLuongBan = int.Parse(Console.ReadLine());

        }

        public NhanVienBanHang() : base()
        {

        }
        public NhanVienBanHang(string hoTen, DateTime ngayTD, int soLuongBan):base(hoTen, ngayTD)
        {
            this.soLuongBan = soLuongBan;
        }
        public int TinhTienHoaHong()
        {
            if (soLuongBan > 500)
            {
                return 3000;
            }
            else if (soLuongBan >= 100)
            {
                return 2000;
            }
            else
            {
                return 1000;
            }
        }
    }
}
