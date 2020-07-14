using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;

namespace Staff
{
    public class SupportStaff : Staff
    {
        private string department;

        //properties
        public string Department
        {
            get { return department; }
            set {
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
                department = value;
            }
        }

        public override void AddStaff()
        {
            bool succeed;
            base.AddStaff();
            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine("\nEnter Department");
                    Department = Console.ReadLine();
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
            Console.WriteLine("{0}   Name: {1},  Department: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Department, ContactNumber, DateOfJoin);
        }

        public override void UpdateStaff()
        {
            bool succeed;
            string input;
            base.UpdateStaff();
            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine($"\nEnter Department ({this.Department}) ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Department = this.Department;

                    }
                    else
                    {
                        Department = input;
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
