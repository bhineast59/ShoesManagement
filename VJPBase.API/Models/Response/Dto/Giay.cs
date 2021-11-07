using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class Giay
    {
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
