using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class Cthdnhap
    {
        public string MaHdn { get; set; }
        public int? MaSp { get; set; }
        public int? SoLuong { get; set; }
        public double? GiaNhap { get; set; }
        public int Id { get; set; }

        public virtual HoaDonNhap MaHdnNavigation { get; set; }
        public virtual Giay MaSpNavigation { get; set; }
    }
}
