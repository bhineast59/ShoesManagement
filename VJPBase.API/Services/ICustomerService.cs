using ShoesAPI.Models.Response.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Services
{
    public interface ICustomerService
    {
        List<CustomerInfoResponse> GetAllCustomer();
    }
}
