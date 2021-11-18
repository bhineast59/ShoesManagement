using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int IdchucVu { get; set; }
        public string TenChucVu { get; set; }
        public double? Luong { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
