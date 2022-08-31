using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore.Models
{
    public partial class SanPham
    {
        public string Masp { get; set; }
        public string Tensp { get; set; }
        public int? Soluong { get; set; }
        public double? Dongia { get; set; }
        public string Maloai { get; set; }

        public virtual LoaiSanPham MaloaiNavigation { get; set; }
    }
}
