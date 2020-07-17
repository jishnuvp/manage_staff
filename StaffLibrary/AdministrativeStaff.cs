using System;

namespace StaffLibrary
{
    
    public class AdministrativeStaff : Staff
    {

        //properties
        public string Role { get; set; }
        public AdministrativeStaff(string Name, string EmpCode, StaffTypes StaffType, string Role, string ContactNumber, DateTime DateOfJoin) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin)
        {
            this.Role = Role;
        }
        public AdministrativeStaff() { }
    }
}
