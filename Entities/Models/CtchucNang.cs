using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesAPI.Models
{
    public partial class CtchucNang
    {
        public string Id { get; set; }
        public string MaCn { get; set; }

        public virtual TaiKhoan IdNavigation { get; set; }
        public virtual ChucNang MaCnNavigation { get; set; }
    }
}
