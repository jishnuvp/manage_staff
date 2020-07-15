using System;

namespace Staff
{
    public class AdministrativeStaff : Staff
    {

        //properties
        public string Role { get; set; }
        public AdministrativeStaff(string Name, string EmpCode, StaffTypes StaffType, string Role, string ContactNumber, DateTime DateOfJoin) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin)
        {
            this.Name = Name;
            this.EmpCode = EmpCode;
            this.StaffType = StaffType;
            this.Role = Role;
            this.ContactNumber = ContactNumber;
            this.DateOfJoin = DateOfJoin;
        }

    }
}
