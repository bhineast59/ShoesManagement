using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class Ctgiay
    {
        public int Idsize { get; set; }
        public int Idgiay { get; set; }
        public int? Soluongsize { get; set; }

        public virtual Giay IdgiayNavigation { get; set; }
        public virtual Size IdsizeNavigation { get; set; }
    }
}
