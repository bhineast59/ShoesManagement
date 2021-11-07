using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class ThuongHieu
    {
        public ThuongHieu()
        {
            Giays = new HashSet<Giay>();
        }

        public int IdthuongHieu { get; set; }
        public string TenThuongHieu { get; set; }

        public virtual ICollection<Giay> Giays { get; set; }
    }
}
