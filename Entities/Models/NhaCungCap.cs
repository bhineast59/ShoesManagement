﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string GiamDoc { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }

        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
