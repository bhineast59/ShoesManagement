using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response
{
    public class ProductInfoResponse
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
        public string TenThuongHieu { get; set; }
    }
}
