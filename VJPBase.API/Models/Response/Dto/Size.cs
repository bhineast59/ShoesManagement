using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class Size
    {
        public int Idsize { get; set; }
        public double SizeGiay { get; set; }

        public virtual ICollection<Ctgiay> Ctgiays { get; set; }
    }
}
