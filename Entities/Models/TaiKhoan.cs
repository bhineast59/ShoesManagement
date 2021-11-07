using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            CtchucNangs = new HashSet<CtchucNang>();
        }

        public string Id { get; set; }
        public string Password { get; set; }
        public int? TrangThai { get; set; }

        public virtual NhanVien IdNavigation { get; set; }
        public virtual ICollection<CtchucNang> CtchucNangs { get; set; }
    }
}
