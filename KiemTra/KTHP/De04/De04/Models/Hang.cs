using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable

namespace De04.Models
{
    public partial class Hang
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int? DonGiaBan { get; set; }
        public int? SoLuongCon { get; set; }
        public string MaDm { get; set; }

        public string thanhTien()
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");
            int a = (int)(DonGiaBan * SoLuongCon);
            string b = a.ToString("#,###", cultureInfo.NumberFormat);
            return b;
        }

        public virtual DanhMucHang MaDmNavigation { get; set; }
    }
}
