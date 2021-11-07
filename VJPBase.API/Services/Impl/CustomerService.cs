using ShoesAPI.Helpers;
using ShoesAPI.Models.Response.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private readonly QLBanGiayDbContext _context;

        public CustomerService(
            QLBanGiayDbContext context)
        {
            _context = context;
        }
        public List<CustomerInfoResponse> GetAllCustomer()
        {
            var lst = _context.KhachHangs.Select(p =>
                new CustomerInfoResponse
                {
                    MaKh = p.MaKh,
                    HoTenKh = p.HoTenKh,
                    DiaChi = p.DiaChi,
                    Sdt = p.Sdt,                
                }).DefaultIfEmpty().ToList();
            return lst;
        }
        public List<CustomerInfoResponse> FindCustomerName(FindCustomerNameRequest name)
        {
            var lst = GetAllCustomer().Where(p => p.TenGiay.IndexOf(name.TenGiay, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            return lst;
        }
    }
}
