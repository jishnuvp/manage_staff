using System;

namespace StaffLibrary
{
    
    public class AdministrativeStaff : Staff
    {

        //properties
        public string Role { get; set; }
        public AdministrativeStaff(string Name, string EmpCode, StaffTypes StaffType, string Role, string ContactNumber, DateTime DateOfJoin, int Id = 0) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin, Id)
        {
            this.Role = Role;
        }
        public AdministrativeStaff() { }
    }
}
