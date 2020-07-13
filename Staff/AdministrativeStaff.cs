using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;

namespace Staff
{
    class AdministrativeStaff : Staff
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

        public override void AddStaff()
        {
            bool succeed;
            base.AddStaff();
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
            Console.WriteLine("{0}   Name: {1},  Role: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Role, ContactNumber, DateOfJoin);

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

        //public override void EditMenu()
        //{
        //    Console.WriteLine("1. Name");
        //    Console.WriteLine("2. Role");
        //    Console.WriteLine("3. Contact Number");
        //    Console.WriteLine("4. Joined Date");
        //    Console.WriteLine("5. Back to Home\n");
        //}

        public override void SerializeData(TextWriter writer)
        {

            //XmlSerializer serializer = new XmlSerializer(this.GetType());
            //TextWriter writer = new StreamWriter(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.xml");
            //serializer.Serialize(writer, this);
            //writer.Close();
        }

        public override void DeserializeData()
        {

        }
    }
}
