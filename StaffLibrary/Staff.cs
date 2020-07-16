using System;

namespace Staff
{
    public enum StaffTypes { Teaching = 1, Administrative = 2, Support = 3 };
    public class Staff
    {
        //properties
        public StaffTypes StaffType { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfJoin { get; set; }

        public Staff()
        {

        }
        public Staff(string Name, string EmpCode, StaffTypes StaffType, string ContactNumber, DateTime DateOfJoin)
        {
            this.Name = Name;
            this.EmpCode = EmpCode;
            this.StaffType = StaffType;
            this.ContactNumber = ContactNumber;
            this.DateOfJoin = DateOfJoin;
        }
    }
}
