using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class Cthdban
    {
        public string MaHdb { get; set; }
        public int MaSp { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }

        public virtual HoaDonBan MaHdbNavigation { get; set; }
        public virtual Giay MaSpNavigation { get; set; }
    }
}
