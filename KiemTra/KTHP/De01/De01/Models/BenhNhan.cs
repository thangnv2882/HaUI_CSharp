using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable

namespace De01.Models
{
    public partial class BenhNhan
    {
        public int MaBn { get; set; }
        public string HoTen { get; set; }
        public int? SoNgayNamVien { get; set; }
        public double? VienPhi { get; set; }
        public int? MaKhoa { get; set; }

        public string thanhTien()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");
            int a = (int)SoNgayNamVien * 200000;
            string b = a.ToString("#,###", cultureInfo.NumberFormat);
            return b;
        }

        public virtual Khoa MaKhoaNavigation { get; set; }
    }
}
