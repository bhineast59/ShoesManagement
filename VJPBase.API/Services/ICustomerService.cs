using ShoesAPI.Models.Requests;
using ShoesAPI.Models.Response;
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
        public List<CustomerInfoResponse> FindCustomerName(FindCustomerNameRequest name);
        public bool RemoveProduct(RemoveCustomerRequest remove);
        public bool CreateCustomer(UpdateAddCustomerRequest model);
        public bool UpdateCustomer(int id, UpdateAddCustomerRequest model);
    }
}
