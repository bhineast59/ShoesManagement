using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesAPI.Models.Requests;
using ShoesAPI.Services;
using ShoesAPI.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VJPBase.API.Authorization;

namespace ShoesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {     
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet("get-all-product")]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetAllProduct();
            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("ThuongHieu")]
        public IActionResult GetThuongHieu()
        {
            var products = _productService.GetThuongHieu();
            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("Color")]
        public IActionResult GetColor()
        {
            var products = _productService.GetColor();
            return Ok(products);
        }

        [AllowAnonymous]
        [HttpPost("find-product")]
        public IActionResult FindProductName(FindProductNameRequest name)
        {
            var products = _productService.FindProductName(name);
            return Ok(products);
        }
        [AllowAnonymous]
        [HttpPost("add-product")]
        public IActionResult CreateProduct(AddProductRequest model)
        {
            var products = _productService.CreateProduct(model);
            return Ok(products);
        }
        [AllowAnonymous]
        [HttpPost("update-product")]
        public IActionResult UpdateProduct(int idgiay, AddProductRequest model)
        {
            var products = _productService.UpdateProduct(idgiay,model);
            return Ok(products);
        }
        [AllowAnonymous]
        [HttpPost("remove-product")]
        public IActionResult RemoveProduct(RemoveProductRequest remove)
        {
            var students = _productService.RemoveProduct(remove);
            return Ok(students);
        }
    }
}
