using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StaffLibrary;
using StaffLibrary.DbManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffsAPI.Controllers
{
    [Route("staff")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
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

        [HttpPost]
        public IActionResult Post([FromBody] Object staff)
        {
           
            var jsonString = staff.ToString();
            var temp = (int)JObject.Parse(jsonString)["staffType"];
            StaffTypes type = (StaffTypes)temp;

            List<Staff> StaffList = new List<Staff>();
            if (type == StaffTypes.Teaching)
            {
                TeachingStaff obj = JsonConvert.DeserializeObject<TeachingStaff>(jsonString);
                StaffList.Add(obj);
            }
            if(type == StaffTypes.Administrative)
            {
                AdministrativeStaff obj = JsonConvert.DeserializeObject<AdministrativeStaff>(jsonString);
                StaffList.Add(obj);
            }
            if(type == StaffTypes.Support)
            {
                SupportStaff obj = JsonConvert.DeserializeObject<SupportStaff>(jsonString);
                StaffList.Add(obj);
            }
            DataBaseManager dataBaseManager = new DataBaseManager();
            try { 
                dataBaseManager.AddStaffToType(StaffList);
                return StatusCode(201);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Object staff)
        {
            var jsonString = staff.ToString();
            var temp = (int)JObject.Parse(jsonString)["staffType"];
            StaffTypes type = (StaffTypes)temp;
            DataBaseManager dataBaseManager = new DataBaseManager();
            try
            {
                if (type == StaffTypes.Teaching)
                {
                    TeachingStaff obj = JsonConvert.DeserializeObject<TeachingStaff>(jsonString);
                    dataBaseManager.UpdateStaff(obj);
                    return StatusCode(201);
                }
                if (type == StaffTypes.Administrative)
                {
                    AdministrativeStaff obj = JsonConvert.DeserializeObject<AdministrativeStaff>(jsonString);
                    dataBaseManager.UpdateStaff(obj);
                    return StatusCode(201);
                }
                if (type == StaffTypes.Support)
                {
                    SupportStaff obj = JsonConvert.DeserializeObject<SupportStaff>(jsonString);
                    dataBaseManager.UpdateStaff(obj);
                    return StatusCode(201);
                }

                return NotFound(); 
            }
            catch (Exception e)
            {
                return StatusCode(500);
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

