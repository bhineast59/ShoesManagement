using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class Cthdnhap
    {
        public string MaHdn { get; set; }
        public int MaSp { get; set; }
        public int? SoLuong { get; set; }
        public double? GiaNhap { get; set; }

        public virtual HoaDonNhap MaHdnNavigation { get; set; }
        public virtual Giay MaSpNavigation { get; set; }
    }
}
