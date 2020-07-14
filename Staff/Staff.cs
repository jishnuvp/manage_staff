using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace Staff
{
    public enum StaffTypes { Teaching, Administrative, Support };
    public abstract class Staff
    {
        private string name;

        private string contactNumber;

        private DateTime dateOfJoin;



        //properties

        public StaffTypes StaffType { get; set; }
        public string EmpCode { get; set; }
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

        public string ContactNumber
        {
            get { return contactNumber; }
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
                contactNumber = value; 
            }
        }

        public DateTime DateOfJoin
        {
            get { return dateOfJoin; }
            set {
                if (value != null) {
                    string startDateInfo = System.Configuration.ConfigurationManager.AppSettings["startDate"];
                    int[] startDateArray = Array.ConvertAll(startDateInfo.Split(','), int.Parse);
                    DateTime startDate = new DateTime(startDateArray[0], startDateArray[1], startDateArray[2]);
                    DateTime endDate = DateTime.Now;
                    if (value >= startDate && value <= endDate)
                    {
                        dateOfJoin = value;
                    }
                    else
                    {
                        throw new Exception("Date must in between of " + startDate + "And " + endDate);
                    }
                }
            }
        }

        //methods

        public virtual void AddStaff(Enum type, List<Staff> list)
        {
            bool succeed;
            string code;
            StaffType = (StaffTypes)type;
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
                Console.WriteLine("\nEnter Employee code :");
                code = Console.ReadLine();
                if (list.Exists(x => x.EmpCode == code)){
                    succeed = false;   
                }
                else
                {
                    EmpCode = code;
                    succeed = true;
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
        public abstract void ViewStaff();
        public virtual void UpdateStaff()
        {
            DateTime dateInput;
            bool succeed;
            int choice;
            string input;
            //EditMenu();
            //if (!Int32.TryParse(Console.ReadLine(), out choice))
            //{
            //    Console.WriteLine("Enter a valid Sl Number");
            //    return;
            //}
            do
            {
                succeed = false;
                try
                {
                    Console.WriteLine($"Enter Name ({this.Name})");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Name = this.Name;

                    }
                    else
                    {
                        Name = input;
                    }
                    succeed = true;
                    Console.WriteLine("Name updated succesfully");
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
                    Console.WriteLine($"\nEnter Contact Number ({this.ContactNumber})");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        ContactNumber = this.ContactNumber;

                    }
                    else
                    {
                        ContactNumber = input;
                    }
                    succeed = true;
                    Console.WriteLine("Contact Number updated succesfully");
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
                    Console.WriteLine($"\nEnter Date of Join ({this.DateOfJoin}) (dd-mm-yyyy) ");
                    if(! (DateTime.TryParse(Console.ReadLine(), out dateInput)))
                    {
                        DateOfJoin = this.DateOfJoin;
                    }
                    else
                    {
                        DateOfJoin = dateInput;
                    }
                    
                    succeed = true;
                    Console.WriteLine("Date of Join updated succesfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (succeed == false);


            
        }


    }
}
