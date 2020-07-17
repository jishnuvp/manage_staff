using System;
using System.Xml.Serialization;

//public enum SubjectEnum { malayalam, english, maths, social, science, hindi };


namespace StaffLibrary
{
    public class TeachingStaff : Staff
    {

        //properties
        public string Subject { get; set; }
        public TeachingStaff()
        {

        }
        public TeachingStaff(string Name, string EmpCode, StaffTypes StaffType, string Subject, string ContactNumber, DateTime DateOfJoin) : base(Name, EmpCode, StaffType, ContactNumber, DateOfJoin)
        {
            this.Subject = Subject;
        }


    }
}
