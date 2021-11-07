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
        public List<ProductInfoResponse> FindProductName(FindProductNameRequest name);
        bool RemoveProduct(RemoveProductRequest remove);
    }
}
