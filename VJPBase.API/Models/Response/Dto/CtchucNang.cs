using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Models.Response.Dto
{
    public class CtchucNang
    {
        public string Id { get; set; }
        public string MaCn { get; set; }

        public virtual TaiKhoan IdNavigation { get; set; }
        public virtual ChucNang MaCnNavigation { get; set; }
    }
}
