using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace StaffLibrary
{
    public class SerializeJson
    {
        public void Serialize(List<Staff> StaffList)
        {
            using (StreamWriter file = File.CreateText(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.json"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, StaffList);
            }

        }
        public bool DeSerialize(List<Staff> StaffList)
        {
            bool flag = false;
            try
            {
                string jsonString = File.ReadAllText(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.json");
                object obj = JsonConvert.DeserializeObject(jsonString);
                foreach (var staff in (dynamic)obj)
                {
                    Console.WriteLine(staff);
                    string staffType = staff.StaffType.ToString();
                    switch (staffType)
                    {
                        case "Teaching":
                            TeachingStaff ts = (TeachingStaff)staff.ToObject(typeof(TeachingStaff));
                            TeachingStaff teachingStaff = new TeachingStaff(ts.Name, ts.EmpCode, ts.StaffType, ts.Subject, ts.ContactNumber, ts.DateOfJoin);
                            StaffList.Add(teachingStaff);
                            break;
                        case "Administrative":
                            AdministrativeStaff adminStaff = (AdministrativeStaff)staff.ToObject(typeof(AdministrativeStaff));
                            AdministrativeStaff administrativeStaff = new AdministrativeStaff(adminStaff.Name, adminStaff.EmpCode, adminStaff.StaffType, adminStaff.Role, adminStaff.ContactNumber, adminStaff.DateOfJoin);
                            StaffList.Add(administrativeStaff);
                            break;
                        case "Support":
                            SupportStaff ss = (SupportStaff)staff.ToObject(typeof(SupportStaff));
                            SupportStaff supportStaff = new SupportStaff(ss.Name, ss.EmpCode, ss.StaffType, ss.Department, ss.ContactNumber, ss.DateOfJoin);
                            StaffList.Add(supportStaff);
                            break;
                    }

                }

            }
            catch (Exception e)
            {
                return flag ;
            }


            return flag;
        }
    }
}
