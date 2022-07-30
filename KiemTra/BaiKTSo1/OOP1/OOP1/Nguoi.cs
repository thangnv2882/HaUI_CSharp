using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    internal class Nguoi
    {
        private string hoTen;
        private string diaChi;
      

        public virtual void Nhap()
        {
            Console.Write("Họ tên: ");
            hoTen = Console.ReadLine();
            Console.Write("Địa chỉ: ");
            diaChi = Console.ReadLine();
        }

        public void setHoTen(string hoTen)
        {
            this.hoTen = hoTen;
        }

        public String getHoTen()
        {
            return hoTen;
        }

        public void setDiaChi(string diaChi)
        {
            this.diaChi = diaChi;
        }

        public String getDiaChi()
        {
            return diaChi;
        }

    }
}
