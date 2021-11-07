using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Requests
{
    public class FindCustomerNameRequest
    {
        [Required]
        public string HoTenKh { get; set; }
    }
}
