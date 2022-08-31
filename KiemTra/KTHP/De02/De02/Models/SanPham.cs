using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable

namespace De02.Models
{
    public partial class SanPham
    {
        public int MaSp { get; set; }
        public string TenSanPham { get; set; }
        public double? DonGia { get; set; }
        public double? SoLuongBan { get; set; }
        public double? TienBan { get; set; }
        public int? MaNhomHang { get; set; }

        public string tienBan()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");
            double a = (double)(SoLuongBan * DonGia);
            string b = a.ToString("#,###", cultureInfo.NumberFormat);
            return b;
        }

        public virtual NhomHang MaNhomHangNavigation { get; set; }
    }
}
