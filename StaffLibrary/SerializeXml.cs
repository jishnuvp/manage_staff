using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace StaffLibrary
{
    public class SerializeXml : ISerialize
    {
        public void Serialize(List<Staff> StaffList)
        {
            Type[] staffTypes = { typeof(TeachingStaff), typeof(AdministrativeStaff), typeof(SupportStaff) };
            XmlSerializer serializer = new XmlSerializer(typeof(List<Staff>), staffTypes);
            FileStream fs = new FileStream(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\XMLFile1.xml", FileMode.Create);
            serializer.Serialize(fs, StaffList);
            fs.Close();
            StaffList = null;
        }

        public bool DeSerialize(List<Staff> StaffList)
        {
            bool flag = false;
            Type[] staffTypes = { typeof(TeachingStaff), typeof(AdministrativeStaff), typeof(SupportStaff) };

            XmlSerializer deserializer = new XmlSerializer(typeof(List<Staff>), staffTypes);

            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\XMLFile1.xml"))
                {
                    object outObject = deserializer.Deserialize(reader);

                    foreach (var staff in (dynamic)outObject)
                    {
                        string staffType = staff.StaffType.ToString();
                        switch (staffType)
                        {
                            case "Teaching":
                                TeachingStaff teachingStaff = new TeachingStaff(staff.Name, staff.EmpCode, staff.StaffType, staff.Subject, staff.ContactNumber, staff.DateOfJoin);
                                StaffList.Add(teachingStaff);
                                break;
                            case "Administrative":
                                AdministrativeStaff administrativeStaff = new AdministrativeStaff(staff.Name, staff.EmpCode, staff.StaffType, staff.Role, staff.ContactNumber, staff.DateOfJoin);
                                StaffList.Add(administrativeStaff);
                                break;
                            case "Support":
                                SupportStaff supportStaff = new SupportStaff(staff.Name, staff.EmpCode, staff.StaffType, staff.Department, staff.ContactNumber, staff.DateOfJoin);
                                StaffList.Add(supportStaff);
                                break;
                        }

                    }
                    return flag;
                }
            }
            catch (Exception e)
            {
                return flag;
            }
        }


    }
}
