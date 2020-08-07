using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffLibrary;
using StaffLibrary.DbManager;

namespace StaffsAPI
{
    public class APIHelper
    {
        public static List<Staff> PopulateList(List<Staff> StaffList)
        {
            int id;
            string name, code, number, subject, role, department;
            StaffTypes emptType;
            DateTime dateOfJoin;
            List<Staff> staffs = new List<Staff>();
            foreach (var staff in StaffList)
            {
                id = staff.Id;
                name = staff.Name;
                code = staff.EmpCode;
                number = staff.ContactNumber;
                emptType = staff.StaffType;
                dateOfJoin = staff.DateOfJoin;

                if (StaffTypes.Teaching == emptType)
                {
                    TeachingStaff teachingStaff = (TeachingStaff)staff;
                    subject = teachingStaff.Subject;
                    TeachingStaff obj = new TeachingStaff(name, code, emptType, subject, number, dateOfJoin, id);
                    staffs.Add(obj);
                }
                else if (StaffTypes.Administrative == emptType)
                {
                    AdministrativeStaff administrativeStaff = (AdministrativeStaff)staff;
                    role = administrativeStaff.Role;
                    AdministrativeStaff obj = new AdministrativeStaff(name, code, emptType, role, number, dateOfJoin, id);
                    staffs.Add(obj);
                }
                else if (StaffTypes.Support == emptType)
                {
                    SupportStaff supportStaff = (SupportStaff)staff;
                    department = supportStaff.Department;
                    SupportStaff obj = new SupportStaff(name, code, emptType, department, number, dateOfJoin, id);
                    staffs.Add(obj);
                }
            }
            return StaffList;
        }
    }
}
