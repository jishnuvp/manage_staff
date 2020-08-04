using System;

namespace StaffLibrary
{
    public class SupportStaff : Staff
    {

        //properties
        public string Department { get; set; }

        public SupportStaff(string Name, string EmpCode, StaffTypes StaffType, string Department, string ContactNumber, DateTime DateOfJoin, int Id = 0) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin, Id)
        {
            this.Department = Department;
        }
        public SupportStaff() { }

    }
}
