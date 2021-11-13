using ShoesAPI.Models.Requests;
using ShoesAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Services
{
    public interface IProductService
    {
        List<ProductInfoResponse> GetAllProduct();
        public List<ProductInfoResponse> GetThuongHieu();
        public List<ProductInfoResponse> GetColor();
        public List<ProductInfoResponse> FindProductName(FindProductNameRequest name);
        public bool CreateProduct(AddProductRequest model);
        public bool UpdateProduct(int idgiay, AddProductRequest model);
        bool RemoveProduct(RemoveProductRequest remove);
    }
}
