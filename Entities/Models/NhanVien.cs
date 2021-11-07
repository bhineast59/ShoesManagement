using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        public string MaNv { get; set; }
        public string Cmnd { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public double? Luong { get; set; }
        public string Sdt { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
