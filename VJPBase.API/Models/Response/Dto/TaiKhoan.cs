using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class TaiKhoan
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int? TrangThai { get; set; }

        public virtual NhanVien IdNavigation { get; set; }
        public virtual ICollection<CtchucNang> CtchucNangs { get; set; }
    }
}
