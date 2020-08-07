using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("type/{type}")]
        public IActionResult GetAllStaffByType(StaffTypes type)
        {
            var temp = Enum.IsDefined(typeof(StaffTypes), type);
            if (Enum.IsDefined(typeof(StaffTypes), type))
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = dataBaseManager.FetchStaffByCategory(type);
                if(type == StaffTypes.Teaching)
                {
                    List<TeachingStaff> staffs = new List<TeachingStaff>();
                    foreach(var staff in StaffList)
                    {
                        TeachingStaff teachingStaff = (TeachingStaff)staff;
                        TeachingStaff obj = new TeachingStaff(teachingStaff.Name, teachingStaff.EmpCode, teachingStaff.StaffType, teachingStaff.Subject, teachingStaff.ContactNumber, teachingStaff.DateOfJoin, teachingStaff.Id);
                        staffs.Add(obj);
                    }
                    return Ok(new { staffs });
                }
                if (type == StaffTypes.Administrative)
                {
                    List<AdministrativeStaff> staffs = new List<AdministrativeStaff>();
                    foreach (var staff in StaffList)
                    {
                        AdministrativeStaff adminStaff = (AdministrativeStaff)staff;
                        AdministrativeStaff obj = new AdministrativeStaff(adminStaff.Name, adminStaff.EmpCode, adminStaff.StaffType, adminStaff.Role, adminStaff.ContactNumber, adminStaff.DateOfJoin, adminStaff.Id);
                        staffs.Add(obj);
                    }
                    return Ok(new { staffs });
                }
                if (type == StaffTypes.Support)
                {
                    List<SupportStaff> staffs = new List<SupportStaff>();
                    foreach (var staff in StaffList)
                    {
                        SupportStaff supportStaff = (SupportStaff)staff;
                        SupportStaff obj = new SupportStaff(supportStaff.Name, supportStaff.EmpCode, supportStaff.StaffType, supportStaff.Department, supportStaff.ContactNumber, supportStaff.DateOfJoin, supportStaff.Id);
                        staffs.Add(obj);
                    }
                    return Ok(new { staffs });
                }
                return null;
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
                foreach(var staff in StaffList)
                {
                    var temp = staff.StaffType;
                    var name = staff.Name;
                    if(StaffTypes.Teaching == staff.StaffType)
                    {
                        TeachingStaff teachingStaff = (TeachingStaff)staff;
                        TeachingStaff obj = new TeachingStaff(teachingStaff.Name, teachingStaff.EmpCode, teachingStaff.StaffType, teachingStaff.Subject, teachingStaff.ContactNumber, teachingStaff.DateOfJoin, teachingStaff.Id);
                        return Ok(new { obj });
                    }
                    if(StaffTypes.Administrative == staff.StaffType)
                    {
                        AdministrativeStaff adminStaff = (AdministrativeStaff)staff;
                        AdministrativeStaff obj = new AdministrativeStaff(adminStaff.Name, adminStaff.EmpCode, adminStaff.StaffType, adminStaff.Role, adminStaff.ContactNumber, adminStaff.DateOfJoin, adminStaff.Id);
                        return Ok(new { obj });
                    }
                    if (StaffTypes.Support == staff.StaffType)
                    {
                        SupportStaff supportStaff = (SupportStaff)staff;
                        SupportStaff obj = new SupportStaff(supportStaff.Name, supportStaff.EmpCode, supportStaff.StaffType, supportStaff.Department, supportStaff.ContactNumber, supportStaff.DateOfJoin, supportStaff.Id);
                        return Ok(new { obj });
                    }
                }

                return null;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Teaching")]
        public IActionResult PostTeachingStaff([FromBody] TeachingStaff staff)
        {
            if(string.IsNullOrEmpty(staff.Name) && string.IsNullOrEmpty(staff.EmpCode) && string.IsNullOrEmpty(staff.ContactNumber)
                && staff.DateOfJoin != null && Enum.IsDefined(typeof(StaffTypes), staff.StaffType))
            {
                return StatusCode(500);
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
            if (string.IsNullOrEmpty(staff.Name) && string.IsNullOrEmpty(staff.EmpCode) && string.IsNullOrEmpty(staff.ContactNumber) && string.IsNullOrEmpty(staff.Role)
                && staff.DateOfJoin != null && Enum.IsDefined(typeof(StaffTypes), staff.StaffType))
            {
                return StatusCode(500);
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
            if (string.IsNullOrEmpty(staff.Name) && string.IsNullOrEmpty(staff.EmpCode) && string.IsNullOrEmpty(staff.ContactNumber) && string.IsNullOrEmpty(staff.Department)
                && staff.DateOfJoin != null && Enum.IsDefined(typeof(StaffTypes), staff.StaffType))
            {
                return StatusCode(500);
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

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                dataBaseManager.DeleteStaff(id);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [HttpGet]
        public string GetAllStaff()
        {
            return "test";
        }

    }
}

