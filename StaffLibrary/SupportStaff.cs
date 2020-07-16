using System;

namespace Staff
{
    public class SupportStaff : Staff
    {

        //properties
        public string Department { get; set; }

        public SupportStaff(string Name, string EmpCode, StaffTypes StaffType, string Department, string ContactNumber, DateTime DateOfJoin) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin)
        {
            this.Department = Department;
        }
        public SupportStaff() { }

    }
}
