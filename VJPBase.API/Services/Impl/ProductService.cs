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
                    Color = p.IdcolorNavigation.Color1,
                    Idcolor = p.Idcolor,
                    IdthuongHieu = p.IdthuongHieu
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
                    Cover = model.Cover.ToString(),
                    Mota = model.Mota,
                    SoLuongTon = model.SoLuongTon,
                    Idcolor = _context.Colors.Where(p => p.Color1 == model.Color).Select(p => p.Idcolor).FirstOrDefault(),
                    IdthuongHieu = _context.ThuongHieus.Where(p => p.TenThuongHieu == model.TenThuongHieu).Select(p => p.IdthuongHieu).FirstOrDefault()

                    //IdthuongHieuNavigation = new ThuongHieu()
                    //{
                    //    TenThuongHieu = model.TenThuongHieu,
                    //    IdthuongHieu = _context.ThuongHieus.Where(p => p.TenThuongHieu == model.TenThuongHieu).Select(p => p.IdthuongHieu).FirstOrDefault()
                    //},
                    //IdcolorNavigation = new Color()
                    //{
                    //    Color1 = model.Color,
                    //    Idcolor = _context.Colors.Where(p => p.Color1 == model.Color).Select(p => p.Idcolor).FirstOrDefault()
                    //},
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
        public List<ProductInfoResponse> UpdateProduct(int id, AddProductRequest model)
        {
            var products = _context.Giays.Where(p => p.Idgiay == model.Id).FirstOrDefault();
            var thuonghieus = _context.ThuongHieus.Where(p => p.TenThuongHieu == model.TenThuongHieu).FirstOrDefault();
            var colors = _context.Colors.Where(p => p.Color1 == model.Color).FirstOrDefault();

            products.IdthuongHieuNavigation = thuonghieus;
            products.IdcolorNavigation = colors;
            products.Idcolor = colors.Idcolor;
            products.IdthuongHieu = thuonghieus.IdthuongHieu;

            products.TenGiay = model.TenGiay;
            products.Dongia = model.Dongia;
            products.Cover = model.Cover.ToString();
            products.Mota = model.Mota;
            products.SoLuongTon = model.SoLuongTon;
               //pro.th.IdthuongHieu = (int)model.IdthuongHieu;
               //pro.co.Idcolor = (int)model.Idcolor;
               //pro.th.TenThuongHieu = model.TenThuongHieu;                    
            _context.Giays.Update(products);
            _context.SaveChanges();
            return GetAllProduct();
        }

    }
}
