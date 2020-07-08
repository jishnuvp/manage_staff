using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Staff
{
    class SupportStaff : Staff
    {
        private string department;
        //constructor

        public SupportStaff()
        {
             
        }
        public SupportStaff(string name, string department, string contact_number, DateTime date_of_join) : base(name, contact_number, date_of_join)
        {
            this.Name = name;
            this.Department = department;
            this.ContactNumber = contact_number;
            this.DateOfJoin = date_of_join;
        }

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

        public void addStaff()
        {
            bool succeed;

            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine("\nEnter Name: ");
                    Name = Console.ReadLine();
                    succeed = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (succeed == false);

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

            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine("\nEnter Contact Number");
                    ContactNumber = Console.ReadLine();
                    succeed = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (succeed == false);

            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine("\nEnter Date of Join (dd-mm-yyyy)");
                    DateOfJoin = DateTime.Parse(Console.ReadLine());
                    succeed = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (succeed == false);
        }
        public void viewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1},  Department: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Department, ContactNumber, DateOfJoin);
        }

        public void updateStaff()
        {
            int choice;
            bool succeed;
            Console.WriteLine("\nSelect the field that you want to update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Department");
            Console.WriteLine("3. Contact Number");
            Console.WriteLine("4. Joined Date");
            Console.WriteLine("5. Back to Home\n");
            if (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Enter a valid Sl Number");
                return;
            }
            switch (choice)
            {
                case 1:
                    do
                    {
                        succeed = false;
                        try
                        {
                            Console.WriteLine("\nEnter Name: ");
                            Name = Console.ReadLine();
                            succeed = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (succeed == false);
                    Console.WriteLine("Name updated succesfully");
                    break;
                case 2:
                    do
                    {
                        succeed = false;
                        try
                        {
                            Console.WriteLine("\nEnter Department: ");
                            Department = Console.ReadLine();
                            succeed = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (succeed == false);
                    Console.WriteLine("Subject updated succesfully");
                    break;
                case 3:
                    do
                    {
                        succeed = false;
                        try
                        {
                            Console.WriteLine("\nEnter Contact Number");
                            ContactNumber = Console.ReadLine();
                            succeed = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (succeed == false);
                    Console.WriteLine("Contact number updated succesfully");
                    break;
                case 4:
                    do
                    {
                        succeed = false;
                        try
                        {
                            Console.WriteLine("\nEnter Date of Join (dd-mm-yyyy)");
                            DateOfJoin = DateTime.Parse(Console.ReadLine());
                            succeed = true;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    } while (succeed == false);
                    Console.WriteLine("Joined date updated succesfully");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Enter a valid choice");
                    this.updateStaff(); break;
            }
        }
    }
}
