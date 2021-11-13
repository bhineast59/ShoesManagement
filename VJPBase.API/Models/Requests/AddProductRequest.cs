using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Requests
{
    public class AddProductRequest
    {
        [Required]
        public string TenGiay { get; set; }
        [Required]
        public string Mota { get; set; }
        [Required]
        public double? Dongia { get; set; }
        [Required]
        public int? SoLuongTon { get; set; }
        [Required]
        public string Cover { get; set; }

        //Table Color
        public int? Idcolor { get; set; }

        public string Color { get; set; }

        //Table ThuongHieu
        public int? IdthuongHieu { get; set; }

        public string TenThuongHieu { get; set; }
        
        
    }
}
