using System;
using ShoesAPI.Models.Requests;
using ShoesAPI.Models.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShoesAPI.Services
{
    public interface IStaffService
    {
        public List<StaffInfoResponse> GetAllStaff();
        public List<StaffInfoResponse> GetStaffByManager();
        public List<StaffInfoResponse> GetStaffByStaff();
        public List<StaffInfoResponse> FindStaffName(FindStaffRequest name);
        public bool RemoveStaff(RemoveStaffRequest remove);
        public bool CreateStaff(UpdateAddStaffRequest model);
        public List<StaffInfoResponse> UpdateStaffInfo(UpdateAddStaffRequest model);
    }
}
