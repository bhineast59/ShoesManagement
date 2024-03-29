﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class NhanVien
    {
        public string MaNv { get; set; }
        public string Cmnd { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public int? IdchucVu { get; set; }
        public string TaiKhoan { get; set; }
        public string Password { get; set; }
        public int? TrangThai { get; set; }

        public virtual ChucVu IdchucVuNavigation { get; set; }
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
