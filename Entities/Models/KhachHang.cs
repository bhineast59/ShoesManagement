﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
        }

        public int MaKh { get; set; }
        public string HoTenKh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
