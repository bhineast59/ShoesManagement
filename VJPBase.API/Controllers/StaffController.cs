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
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [AllowAnonymous]
        [HttpGet("get-all-staff")]
        public IActionResult GetAllStaff()
        {
            var staffs = _staffService.GetAllStaff();
            return Ok(staffs);
        }
        [AllowAnonymous]
        [HttpGet("get-manager")]
        public IActionResult GetStaffByManager()
        {
            var staffs = _staffService.GetStaffByManager();
            return Ok(staffs);
        }
        [AllowAnonymous]
        [HttpGet("get-staff")]
        public IActionResult GetStaffByStaff()
        {
            var staffs = _staffService.GetStaffByStaff();
            return Ok(staffs);
        }
        [AllowAnonymous]
        [HttpPost("find-staff")]
        public IActionResult FindStaffName(FindStaffRequest name)
        {
            var staffs = _staffService.FindStaffName(name);
            return Ok(staffs);
        }
        [AllowAnonymous]
        [HttpPost("delete-staff")]
        public IActionResult RemoveStaff(RemoveStaffRequest remove)
        {
            var staffs = _staffService.RemoveStaff(remove);
            return Ok(staffs);
        }
        [AllowAnonymous]
        [HttpPost("add-staff")]
        public IActionResult CreateStaff(UpdateAddStaffRequest model)
        {
            var staffs = _staffService.CreateStaff(model);
            return Ok(staffs);
        }
        [AllowAnonymous]
        [HttpPost("update-staff")]
        public IActionResult UpdateStaffInfo(UpdateAddStaffRequest model)
        {
            var staffs = _staffService.UpdateStaffInfo(model);
            return Ok(staffs);
        }
    }
}
