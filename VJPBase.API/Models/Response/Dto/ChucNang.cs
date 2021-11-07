using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class ChucNang
    {
        public string MaCn { get; set; }
        public string TenCn { get; set; }

        public virtual ICollection<CtchucNang> CtchucNangs { get; set; }
    }
}
