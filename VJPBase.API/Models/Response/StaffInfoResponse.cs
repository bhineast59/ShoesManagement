using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response
{
    public class StaffInfoResponse
    {
        public string MaNv { get; set; }
        public string Cmnd { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string TaiKhoan { get; set; }
        public string Password { get; set; }
        public int? TrangThai { get; set; }

        //Table Chuc vu
        public int? IdchucVu { get; set; }
        public string TenChucVu { get; set; }
        public double? Luong { get; set; }
    }
}
