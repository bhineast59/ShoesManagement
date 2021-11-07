using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class ChucNang
    {
        public ChucNang()
        {
            CtchucNangs = new HashSet<CtchucNang>();
        }

        public string MaCn { get; set; }
        public string TenCn { get; set; }

        public virtual ICollection<CtchucNang> CtchucNangs { get; set; }
    }
}
