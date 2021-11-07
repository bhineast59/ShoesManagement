using System;
using System.Collections.Generic;


namespace ShoesAPI.Models
{
    public partial class Ctgiay
    {
        public int Idsize { get; set; }
        public int Idgiay { get; set; }
        public int? Soluongsize { get; set; }

        public virtual Giay IdgiayNavigation { get; set; }
        public virtual Size IdsizeNavigation { get; set; }
    }
}
