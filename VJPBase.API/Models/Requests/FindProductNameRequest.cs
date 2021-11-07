using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Requests
{
    public class FindProductNameRequest
    {
        [Required]
        public string TenGiay { get; set; }
    }
}
