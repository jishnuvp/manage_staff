using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Staff
{
    class Validator
    {
        public static void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Name is required");
            }
            if (value.Length > 10)
            {
                throw new Exception("Name should be less than 10 characters");
            }
            if (!Regex.Match(value, "^[a-zA-Z ']*$").Success)
            {
                throw new Exception("Name must contain characters only");
            }
        }
        public static void ValidatePhoneNumber(string value)
        {
            if (value.Length == 0)
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
        }
        public static void ValidateDate(DateTime value)
        {
            if (value != null)
            {
                string startDateInfo = System.Configuration.ConfigurationManager.AppSettings["startDate"];
                int[] startDateArray = Array.ConvertAll(startDateInfo.Split(','), int.Parse);
                DateTime startDate = new DateTime(startDateArray[0], startDateArray[1], startDateArray[2]);
                DateTime endDate = DateTime.Now;
                if (!(value >= startDate && value <= endDate))
                {
                    throw new Exception("Date must in between of " + startDate + "And " + endDate);
                }
            }
        }
        public static void ValidateRole(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Role is required");
            }
            if (value.Length > 15)
            {
                throw new Exception("Role should be less than 15 characters");
            }
            if (!Regex.Match(value, "^[a-zA-Z ']*$").Success)
            {
                throw new Exception("Role must contain characters only");
            }
        }
        public static void ValidateDepartment(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Department is required");
            }
            if (value.Length > 15)
            {
                throw new Exception("Department should be less than 15 characters");
            }
            if (!Regex.Match(value, "^[a-zA-Z ']*$").Success)
            {
                throw new Exception("Department must contain characters only");
            }
        }
    }
}
