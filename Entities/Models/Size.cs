using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class Size
    {
        public Size()
        {
            Ctgiays = new HashSet<Ctgiay>();
        }

        public int Idsize { get; set; }
        public double SizeGiay { get; set; }

        public virtual ICollection<Ctgiay> Ctgiays { get; set; }
    }
}
