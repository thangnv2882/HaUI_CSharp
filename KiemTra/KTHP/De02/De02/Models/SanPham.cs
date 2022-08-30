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
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            int a = (int)(SoLuongBan * DonGia);
            string b = int.Parse(a.ToString()).ToString("#,###", cul.NumberFormat);
            return b;
        }

        public virtual NhomHang MaNhomHangNavigation { get; set; }
    }
}
