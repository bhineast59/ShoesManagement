using Microsoft.AspNetCore.Mvc;
using ShoesAPI.Models.Requests;
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
        [AllowAnonymous]
        [HttpPost("find-customer")]
        public IActionResult FindCustomerName(FindCustomerNameRequest name)
        {
            var custoemrs = _customerService.FindCustomerName(name);
            return Ok(custoemrs);
        }
        [AllowAnonymous]
        [HttpPost("remove-customer")]
        public IActionResult RemoveCustomer(RemoveCustomerRequest remove)
        {
            var custoemrs = _customerService.RemoveProduct(remove);
            return Ok(custoemrs);
        }
        [AllowAnonymous]
        [HttpPost("create-customer")]
        public IActionResult CreateCustomer(UpdateAddCustomerRequest model)
        {
            var custoemrs = _customerService.CreateCustomer(model);
            return Ok(custoemrs);
        }
        [AllowAnonymous]
        [HttpPost("update-customer")]
        public IActionResult UpdateCustomer(int id, UpdateAddCustomerRequest model)
        {
            var custoemrs = _customerService.UpdateCustomer(id,model);
            return Ok(custoemrs);
        }

    }
}
