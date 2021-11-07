using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class HoaDonBan
    {
        public HoaDonBan()
        {
            Cthdbans = new HashSet<Cthdban>();
        }

        public string MaHdb { get; set; }
        public string MaNv { get; set; }
        public string MaKh { get; set; }
        public DateTime? NgayLapHd { get; set; }
        public DateTime? NgayLayHang { get; set; }
        public double? TongTien { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<Cthdban> Cthdbans { get; set; }
    }
}
