using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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

        public void AddStaff()
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
                    Console.WriteLine("\nEnter Role");
                    Role = Console.ReadLine();
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
        public void ViewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1},  Role: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Role, ContactNumber, DateOfJoin);

        }
        public void UpdateStaff()
        {
            bool succeed;
            int choice;
            Console.WriteLine("\nSelect the field that you want to update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Role");
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
                            Console.WriteLine("\nEnter Role: ");
                            Role = Console.ReadLine();
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
                    this.UpdateStaff(); break;
            }
        }
    }
}
