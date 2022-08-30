using System;
using System.Collections.Generic;

#nullable disable

namespace De04.Models
{
    public partial class DanhMucHang
    {
        public DanhMucHang()
        {
            Hangs = new HashSet<Hang>();
        }

        public string MaDm { get; set; }
        public string TenDm { get; set; }

        public virtual ICollection<Hang> Hangs { get; set; }
    }
}
