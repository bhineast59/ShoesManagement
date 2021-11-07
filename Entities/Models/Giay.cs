using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class Giay
    {
        public Giay()
        {
            Ctgiays = new HashSet<Ctgiay>();
            Cthdbans = new HashSet<Cthdban>();
            Cthdnhaps = new HashSet<Cthdnhap>();
        }

        public int Idgiay { get; set; }
        public string TenGiay { get; set; }
        public string Mota { get; set; }
        public double? Dongia { get; set; }
        public int? SoLuongTon { get; set; }
        public string Cover { get; set; }
        public string GhiChu { get; set; }
        public int? Idcolor { get; set; }
        public int? IdthuongHieu { get; set; }

        public virtual Color IdcolorNavigation { get; set; }
        public virtual ThuongHieu IdthuongHieuNavigation { get; set; }
        public virtual ICollection<Ctgiay> Ctgiays { get; set; }
        public virtual ICollection<Cthdban> Cthdbans { get; set; }
        public virtual ICollection<Cthdnhap> Cthdnhaps { get; set; }
    }
}
