using ShoesAPI.Helpers;
using ShoesAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ShoesAPI.Models.Requests;
using ShoesAPI.Models;

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
                    Mota = p.Mota,
                    SoLuongTon = p.SoLuongTon,
                    TenThuongHieu = p.IdthuongHieuNavigation.TenThuongHieu,
                    Color = p.IdcolorNavigation.Color1
            }).ToList();
            return lst;
        }
        public List<ProductInfoResponse> GetThuongHieu()
        {
            var lst = _context.ThuongHieus.Select(p =>
                new ProductInfoResponse
                {
                    IdthuongHieu = p.IdthuongHieu,
                    TenThuongHieu = p.TenThuongHieu
                }).ToList();
            return lst;
        }
        public List<ProductInfoResponse> GetColor()
        {
            var lst = _context.Colors.Select(p =>
                new ProductInfoResponse
                {
                    Idcolor = p.Idcolor,
                    Color = p.Color1
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
                var a = list.Where(p => p.Idgiay == remove.Idgiay).FirstOrDefault();
                _context.Giays.Remove(a);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool CreateProduct(AddProductRequest model)
        {
            try
            {
                var giay = new Giay()
                {
                    TenGiay = model.TenGiay,
                    Dongia = model.Dongia,
                    Cover = model.Cover,
                    Mota = model.Mota,
                    SoLuongTon = model.SoLuongTon,
                    Idcolor = model.Idcolor,
                    IdthuongHieu = model.IdthuongHieu,
                    /*IdthuongHieuNavigation = new ThuongHieu()
                    {
                        TenThuongHieu = model.TenThuongHieu
                    },
                    IdcolorNavigation = new Color()
                    {
                        Color1 = model.Color
                    },*/                    
                };
                _context.Giays.Add(giay);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool UpdateProduct(int idgiay, AddProductRequest model)
        {
            var products = _context.Giays.ToList();
            var thuonghieus = _context.ThuongHieus.ToList();
            var colors = _context.Colors.ToList();
                   
            try
            {
                var pro = (from product in products
                           join th in thuonghieus on product.IdthuongHieu equals th.IdthuongHieu
                           join co in colors on product.Idcolor equals co.Idcolor
                           where product.Idgiay == idgiay
                           select new { product, th, co }).FirstOrDefault();
                if (pro != null)
                {
                    pro.product.TenGiay = model.TenGiay;
                    pro.product.Dongia = model.Dongia;
                    pro.product.Cover = model.Cover;
                    pro.product.Mota = model.Mota;
                    pro.product.SoLuongTon = model.SoLuongTon;
                    pro.th.IdthuongHieu = (int)model.IdthuongHieu;
                    pro.co.Idcolor = (int)model.Idcolor;
                    pro.th.TenThuongHieu = model.TenThuongHieu;
                    _context.SaveChanges();
                }
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
