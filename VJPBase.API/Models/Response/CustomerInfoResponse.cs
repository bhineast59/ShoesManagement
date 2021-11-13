using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response
{
    public class CustomerInfoResponse
    {
        public int MaKh { get; set; }
        public string HoTenKh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string GhiChu { get; set; }       
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
