using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    internal class NhanVien : Nguoi
    {
        private string maNV;
        private string chucVu;
        private double luongCB; 


        public override void Nhap()
        {
            Console.Write("Ma NV: ");
            maNV = Console.ReadLine();
            base.Nhap();
            Console.Write("Chức vụ: ");
            chucVu = Console.ReadLine();
            Console.Write("Luong CB: ");
            luongCB = double.Parse(Console.ReadLine());


        }

        public int TinhHeSo()
        {
            if (chucVu.CompareTo("Giám đốc") == 0)
                return 10;
            else if (chucVu.CompareTo("Trưởng phòng") == 0 ||
                    chucVu.CompareTo("Phó giám đốc") == 0)
                return 6;
            else if (chucVu.CompareTo("Phó phòng") == 0)
                return 4;
            else
                return 2;
        }

        public void Xuat()
        {
            Console.WriteLine(String.Format("{0, -10}{1, -25}{2, -25}{3, -20}{4, -15}", maNV, base.getHoTen(), base.getDiaChi(), chucVu, luongCB));
        }

        public void setMaNV(string maNV)
        {
            this.maNV = maNV;
        }
        public string getMaNV()
        {
            return maNV;
        }

        public void setChucVu(string chucVu)
        {
            this.chucVu = chucVu;
        }
        public string getChucVu()
        {
            return chucVu;
        }
        public void setLuongCB(double luongCB)
        {
            this.luongCB = luongCB;
        }
        public double getLuongCB()
        {
            return luongCB;
        }

    }
}
