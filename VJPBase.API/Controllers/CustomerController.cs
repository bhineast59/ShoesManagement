using Microsoft.AspNetCore.Mvc;
using ShoesAPI.Services;
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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [AllowAnonymous]
        [HttpGet("get-all-customer")]
        public IActionResult GetAllCustomer()
        {
            var custoemrs = _customerService.GetAllCustomer();
            return Ok(custoemrs);
        }
    }
}
