using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;

namespace Staff
{
    public class AdministrativeStaff : Staff
    {
        private string role;

        //properties
        public string Role
        {
            get { return role; }
            set {
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
                role = value; 
            }
        }

        public override void AddStaff(Enum type)
        {
            bool succeed;
            base.AddStaff(type);
            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine("\nEnter Role");
                    Role = Console.ReadLine();
                    succeed = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (succeed == false);
        }
        public override void ViewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1}, Type: {2}  ,Role: {3},   Contact Number: {4},   Joining Date: {5}", index, Name, staffType, Role, ContactNumber, DateOfJoin);

        }
        public override void UpdateStaff()
        {
            string input;
            base.UpdateStaff();
            bool succeed;
            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine($"\nEnter Role ({this.Role}) ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Role = this.Role;

                    }
                    else
                    {
                        Role = input;
                    }
                    succeed = true;
                    Console.WriteLine("Role updated succesfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (succeed == false);
        }
    }
}
