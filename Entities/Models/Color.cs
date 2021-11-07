using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class Color
    {
        public Color()
        {
            Giays = new HashSet<Giay>();
        }

        public int Idcolor { get; set; }
        public string Color1 { get; set; }

        public virtual ICollection<Giay> Giays { get; set; }
    }
}
