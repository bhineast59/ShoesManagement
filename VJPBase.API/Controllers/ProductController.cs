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
        [HttpPost("find-product")]
        public IActionResult FindProductName(FindProductNameRequest name)
        {
            var products = _productService.FindProductName(name);
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
