using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class Cthdban
    {
        public string MaHdb { get; set; }
        public int? MaSp { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public int Id { get; set; }

        public virtual HoaDonBan MaHdbNavigation { get; set; }
        public virtual Giay MaSpNavigation { get; set; }
    }
}
