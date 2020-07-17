using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json.Converters;

namespace StaffLibrary
{
    public class SerializeJson : ISerialize
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

                //var obj = JsonConvert.DeserializeObject<List<Staff>>(jsonString);

                object staff = JsonConvert.DeserializeObject<Staff>(jsonString);
               // Assert.AreEqual("Jack Russell Terrier", (animal as Dog)?.Breed);



                Console.WriteLine(staff.GetType());

                //foreach (var staff  in (dynamic)obj)
                //{
                //    //Console.WriteLine(staff.Name);
                //    string staffType = staff.StaffType.ToString();
                //    switch (staffType)
                //    {
                //        case "Teaching":
                //            TeachingStaff teachingStaff = new TeachingStaff(staff.Name, staff.EmpCode, staff.StaffType, staff.Subject, staff.ContactNumber, staff.DateOfJoin);
                //            StaffList.Add(teachingStaff);
                //            break;
                //        case "Administrative":
                //            AdministrativeStaff administrativeStaff = new AdministrativeStaff(staff.Name, staff.EmpCode, staff.StaffType, staff.Role, staff.ContactNumber, staff.DateOfJoin);
                //            StaffList.Add(administrativeStaff);
                //            break;
                //        case "Support":
                //            SupportStaff supportStaff = new SupportStaff(staff.Name, staff.EmpCode, staff.StaffType, staff.Department, staff.ContactNumber, staff.DateOfJoin);
                //            StaffList.Add(supportStaff);
                //            break;
                //    }

                //}

            }
            catch (Exception e)
            {
                return flag ;
            }


            return flag;
        }
    }
}
