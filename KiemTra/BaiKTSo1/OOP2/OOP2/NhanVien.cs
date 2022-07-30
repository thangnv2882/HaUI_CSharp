using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class NhanVien
    {
        private string hoTen;
        private DateTime ngayTD;

        public void setHoTen(string hoTen)
        {
            this.hoTen = hoTen;
        }
        public string getHoTen()
        {
            return hoTen;
        }
        public void setNgayTD(DateTime ngayTD)
        {
            this.ngayTD = ngayTD;
        }       
        public DateTime getNgayTD()
        {
            return ngayTD;
        }

        public virtual void Nhap()
        {
            Console.Write("Họ tên: ");
            hoTen = Console.ReadLine();
            Console.Write("Ngày tuyển dụng: ");
            ngayTD = DateTime.Parse(Console.ReadLine());

        }

        protected NhanVien()
        {

        }

        protected NhanVien(string hoTen, DateTime ngayTD)
        {
            this.hoTen = hoTen;
            this.ngayTD = ngayTD;
        }
    }
}
