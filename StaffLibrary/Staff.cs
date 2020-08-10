using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace StaffLibrary
{
    [JsonConverter(typeof(StringEnumConverter))]   // to serialize enum value as string
    public enum StaffTypes { Teaching = 1, Administrative = 2, Support = 3 };

    [JsonConverter(typeof(JsonSubtypes), "StaffType")]
    public class Staff : IStaff
    {
        //properties
        public int Id { get; set; }
        public StaffTypes StaffType { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfJoin { get; set; }

        public Staff()
        {

        }
        public Staff(string Name, string EmpCode, StaffTypes StaffType, string ContactNumber, DateTime DateOfJoin, int Id = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.EmpCode = EmpCode;
            this.StaffType = StaffType;
            this.ContactNumber = ContactNumber;
            this.DateOfJoin = DateOfJoin;
        }
    }
}
