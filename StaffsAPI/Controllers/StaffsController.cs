using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Staff> GetAllStaffByType(StaffTypes type)
        {
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = dataBaseManager.FetchStaffByCategory(type);
                return StaffList;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        // GET api/Staffs//5
        [HttpGet("{id}")]
        public List<Staff> GetStaff(int id)
        {
            try
            {
                DataBaseManager dataBaseManager = new DataBaseManager();
                List<Staff> StaffList = dataBaseManager.FetchStaffInfo(id);
                return StaffList;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        // POST api/<StaffsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StaffsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StaffsController>/5
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
