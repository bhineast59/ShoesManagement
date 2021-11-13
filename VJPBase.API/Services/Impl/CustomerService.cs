using ShoesAPI.Helpers;
using ShoesAPI.Models;
using ShoesAPI.Models.Requests;
using ShoesAPI.Models.Response;
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
            var lst = GetAllCustomer().Where(p => p.HoTenKh.IndexOf(name.HoTenKh, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            return lst;
        }
        public bool RemoveProduct(RemoveCustomerRequest remove)
        {
            try
            {
                var list = _context.KhachHangs.ToList();
                var a = list.Where(p => p.MaKh == remove.MaKh).FirstOrDefault();
                _context.KhachHangs.Remove(a);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool CreateCustomer(UpdateAddCustomerRequest model)
        {        
            try
            {
                var customer = new KhachHang()
                {
                    HoTenKh = model.HoTenKh,
                    DiaChi = model.DiaChi,
                    Sdt = model.Sdt,
                    GhiChu = model.GhiChu
                };
                _context.KhachHangs.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool UpdateCustomer(int id, UpdateAddCustomerRequest model)
        {
            var customer = _context.KhachHangs.Where(p => p.MaKh == id).FirstOrDefault();
            try
            {
                if(customer!= null)
                {
                    customer.HoTenKh = model.HoTenKh;
                    customer.DiaChi = model.DiaChi;
                    customer.Sdt = model.Sdt;
                    customer.GhiChu = model.GhiChu;
                }
                    _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

    }
}
