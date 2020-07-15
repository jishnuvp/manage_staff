using System;
using System.Xml.Serialization;

//public enum SubjectEnum { malayalam, english, maths, social, science, hindi };


namespace Staff
{
    [XmlRoot("TeachingStaff")]
    public class TeachingStaff : Staff
    {
        public TeachingStaff()
        {

        }
        public TeachingStaff(string Name, string EmpCode, StaffTypes StaffType, string Subject, string ContactNumber, DateTime DateOfJoin) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin)
        {
            this.Name = Name;
            this.EmpCode = EmpCode;
            this.StaffType = StaffType;
            this.Subject = Subject;
            this.ContactNumber = ContactNumber;
            this.DateOfJoin = DateOfJoin;
        }

        //properties
        public string Subject { get; set; }


    }
}
