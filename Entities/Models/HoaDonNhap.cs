using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            Cthdnhaps = new HashSet<Cthdnhap>();
        }

        public string MaHdn { get; set; }
        public string MaNv { get; set; }
        public string MaNcc { get; set; }
        public DateTime? NgayLapHd { get; set; }
        public DateTime? NgayNhanHang { get; set; }
        public double? TongTien { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<Cthdnhap> Cthdnhaps { get; set; }
    }
}
