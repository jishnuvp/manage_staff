using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StaffLibrary;
using StaffLibrary.DbManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffsAPI.Controllers
{
    [Route("staff")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        // GET: api/<StaffsController>
        [HttpGet]
        public IActionResult GetAllStaffByType([FromQuery]  StaffTypes type)
        {
            var temp = Enum.IsDefined(typeof(StaffTypes), type);
            if (Enum.IsDefined(typeof(StaffTypes), type))
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = dataBaseManager.FetchStaffByCategory(type);
                return Ok(new { StaffList });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            DataBaseManager dataBaseManager = new DataBaseManager();
            List<Staff> StaffList = dataBaseManager.FetchStaffInfo(id);
            if(StaffList.Count > 0) { 
                var staff = StaffList.First();
                return Ok(new { staff });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Teaching")]
        public IActionResult PostTeachingStaff([FromBody] TeachingStaff staff)
        {
            if (string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.EmpCode) || string.IsNullOrEmpty(staff.ContactNumber) || string.IsNullOrEmpty(staff.Subject)
                || staff.DateOfJoin == null || (Enum.IsDefined(typeof(StaffTypes), staff.StaffType)) != true)
            {
                return ValidationProblem();
            }
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = new List<Staff>();
                StaffList.Add(staff);
                dataBaseManager.AddStaffToType(StaffList);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("Administrative")]
        public IActionResult PostAdministrativeStaff([FromBody] AdministrativeStaff staff)
        {
            if (string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.EmpCode) || string.IsNullOrEmpty(staff.ContactNumber) || string.IsNullOrEmpty(staff.Role)
                || staff.DateOfJoin == null || (Enum.IsDefined(typeof(StaffTypes), staff.StaffType)) != true)
            {
                return ValidationProblem();
            }
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = new List<Staff>();
                StaffList.Add(staff);
                dataBaseManager.AddStaffToType(StaffList);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("Support")]
        public IActionResult PostSupportStaff([FromBody] SupportStaff staff)
        {
            if (string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.EmpCode) || string.IsNullOrEmpty(staff.ContactNumber) || string.IsNullOrEmpty(staff.Department)
                || staff.DateOfJoin == null || (Enum.IsDefined(typeof(StaffTypes), staff.StaffType)) != true)
            {
                return ValidationProblem();
            }
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = new List<Staff>();
                StaffList.Add(staff);
                dataBaseManager.AddStaffToType(StaffList);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        [HttpPut("Teaching/{id}")]
        public IActionResult UpdateTeachingStaff(int id, [FromBody] TeachingStaff staff)
        {
            if (string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.EmpCode) || string.IsNullOrEmpty(staff.ContactNumber) || string.IsNullOrEmpty(staff.Subject)
                || staff.DateOfJoin == null || (Enum.IsDefined(typeof(StaffTypes), staff.StaffType)) != true)
            {
                return ValidationProblem();
            }
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                dataBaseManager.UpdateStaff(staff);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Administrative/{id}")]
        public IActionResult UpdateAdministrativeStaff(int id, [FromBody] AdministrativeStaff staff)
        {
            if (string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.EmpCode) || string.IsNullOrEmpty(staff.ContactNumber) || string.IsNullOrEmpty(staff.Role)
                || staff.DateOfJoin == null || (Enum.IsDefined(typeof(StaffTypes), staff.StaffType)) != true)
            {
                return ValidationProblem();
            }
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                dataBaseManager.UpdateStaff(staff);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Support/{id}")]
        public IActionResult UpdateSupportStaff(int id, [FromBody] SupportStaff staff)
        {
            if (string.IsNullOrEmpty(staff.Name) || string.IsNullOrEmpty(staff.EmpCode) || string.IsNullOrEmpty(staff.ContactNumber) || string.IsNullOrEmpty(staff.Department)
                || staff.DateOfJoin == null || (Enum.IsDefined(typeof(StaffTypes), staff.StaffType)) != true)
            {
                return ValidationProblem();
            }
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                dataBaseManager.UpdateStaff(staff);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool flag = true;
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                flag = dataBaseManager.DeleteStaff(id);
                if (flag)
                    return StatusCode(200);
                else
                    return StatusCode(404);
            }
            catch (Exception exc)
            {
                return StatusCode(200);
            }
        }

    }
}

