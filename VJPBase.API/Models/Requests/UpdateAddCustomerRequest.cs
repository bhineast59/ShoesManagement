using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Requests
{
    public class UpdateAddCustomerRequest
    {
        public int MaKh { get; set; }
        public string HoTenKh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string GhiChu { get; set; }
    }
}
