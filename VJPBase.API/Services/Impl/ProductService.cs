using ShoesAPI.Helpers;
using ShoesAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ShoesAPI.Models.Requests;

namespace ShoesAPI.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly QLBanGiayDbContext _context;

        public ProductService(
            QLBanGiayDbContext context)
        {
            _context = context;
        }
        public List<ProductInfoResponse> GetAllProduct()
        {
            var lst = _context.Giays.Select(p => 
                new ProductInfoResponse {
                    Idgiay = p.Idgiay,
                    TenGiay = p.TenGiay,
                    Dongia = p.Dongia,
                    Cover = p.Cover,
                    TenThuongHieu = p.IdthuongHieuNavigation.TenThuongHieu
            }).ToList();
            return lst;
        }
        public List<ProductInfoResponse> FindProductName(FindProductNameRequest name)
        {
            var lst = GetAllProduct().Where(p => p.TenGiay.IndexOf(name.TenGiay, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            return lst;
        }
        public bool RemoveProduct(RemoveProductRequest remove)
        {
            try
            {
                var list = _context.Giays.ToList();
                _context.Remove(list.Single(p => p.Idgiay == remove.Idgiay));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
