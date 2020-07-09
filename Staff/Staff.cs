using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Staff
{

    abstract class Staff
    {
        private string name;
        private string contact_number;
        //protected string date_of_join;

        private DateTime date_of_join;

        //properties
        public string Name
        {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name is required");
                }
                if(value.Length > 10)
                {
                    throw new Exception("Name should be less than 10 characters");
                }
                if (!Regex.Match(value, "^[a-zA-Z ']*$").Success)
                {
                    throw new Exception("Name must contain characters only"); 
                }
                name = value;
            }
        }

        //[Required, StringLength(10), RegularExpression("/^[0-9]+$/")]
        public string ContactNumber
        {
            get { return contact_number; }
            set {
                if(value.Length == 0)
                {
                    throw new Exception("phone number required ");
                }
                if (value.Length > 10)
                {
                    throw new Exception("phone number must be maximum 10 numbers");
                }
                if (!Regex.Match(value, "^[0-9]*$").Success)
                {
                    throw new Exception("Phone number must be numbers");
                }
                contact_number = value; 
            }
        }

        //[Range(typeof(DateTime), "1/1/1966", "1/1/2020")]
        public DateTime DateOfJoin
        {
            get { return date_of_join; }
            set {
                if (value != null) {
                    string startDateInfo = System.Configuration.ConfigurationManager.AppSettings["startDate"];
                    int[] startDateArray = Array.ConvertAll(startDateInfo.Split(','), int.Parse);
                    DateTime startDate = new DateTime(startDateArray[0], startDateArray[1], startDateArray[2]);
                    DateTime endDate = DateTime.Now;
                    if (value >= startDate && value <= endDate)
                    {
                        date_of_join = value;
                    }
                    else
                    {
                        throw new Exception("Date must in between of " + startDate + "And " + endDate);
                    }
                }
            }
        }
    }
}
