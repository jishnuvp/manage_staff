using System;
using System.Collections.Generic;

namespace Staff
{
    class TeachingStaff
    {
        protected string name;
        private string subject;
        
        //constructor
        public TeachingStaff(string name, string subject)
        {
            this.name = name;
            this.subject = subject;
        }
        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }

    class AdministrativeStaff : TeachingStaff 
    {
        private string role;
        //constructor
        public AdministrativeStaff(string name, string role)
        {
            this.name = name;
            this.role = role;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name, subject;
            string check;
            int staffType;

            //created a list of teaching staff
            List<TeachingStaff> TeachingStaffList = new List<TeachingStaff>();

            //adding values to teaching staff object list
            TeachingStaffList.Add(new TeachingStaff("Jishnu", "Malayalam"));
            TeachingStaffList.Add(new TeachingStaff("Surya dev", "Hindi"));
            TeachingStaffList.Add(new TeachingStaff("Vishnu", "Mathematics"));
            TeachingStaffList.Add(new TeachingStaff("Vijay", "English"));


            do
            {

            // Initial Menu

            Console.WriteLine("----------------------- Manage Staff -----------------------");
            Console.WriteLine("1. Add Staff");
            Console.WriteLine("2. View Staff");
            Console.WriteLine("3. Edit Staff");
            Console.WriteLine("4. Delete Staff");

            Console.WriteLine("Enter your choice(1-4)");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddStaff();
                    break;
                case 2:
                    ViewStaff();
                    break;
                case 3:
                    UpdateStaff();
                    break;
                case 4:
                    DeleteStaff();
                    break;
                }
                Console.WriteLine("Do you want perform more actions (Y/N) ?");
                check = Console.ReadLine();
            } while (check == "Y" || check == "y");


            // function to get the user choice
            int getStaffType()
            {
                Console.WriteLine("1. Teaching Staff");
                Console.WriteLine("2. Administrative Staff");
                Console.WriteLine("3. Support Staff");
                Console.WriteLine("Enter your choice again");
                staffType = Convert.ToInt32(Console.ReadLine());
                return staffType;
            }

            // function for add staff
            void AddStaff()
            {
                staffType = getStaffType();
                switch (staffType)
                {
                    case 1:
                        // add staff
                        Console.WriteLine("----------------------- Add Teaching Staff -----------------------");
                        do
                        {
                            Console.WriteLine("Enter Name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter Subject");
                            subject = Console.ReadLine();
                            TeachingStaffList.Add(new TeachingStaff(name, subject));
                            Console.WriteLine("Do you want to add more staff (Y/N) ?");
                            check = Console.ReadLine();
                        } while (check == "Y" || check == "y");
                        break;

                }
            }

            // function for view staff

            void ViewStaff()
            {
                staffType = getStaffType();
                switch (staffType)
                {
                    case 1:
                        viewTeachingStaff();
                        break;
                }

            }

            // function for update staff details
            void UpdateStaff()
            {
                staffType = getStaffType();
            }

            // function for delete a staff
            void DeleteStaff()
            {
                int trashedStaff;
                staffType = getStaffType();
                switch (staffType)
                {
                    case 1:
                        viewTeachingStaff();
                        Console.WriteLine("Enter the Sl number of the staff that you want to delete");
                        trashedStaff = Convert.ToInt32(Console.ReadLine());
                        if (TeachingStaffList.Count >= trashedStaff)
                        {
                            TeachingStaffList.RemoveAt(trashedStaff - 1);
                            Console.WriteLine($"{trashedStaff} succesfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid Sl number");
                        }
                        viewTeachingStaff();
                        break;
                }
            }

            // function to display teaching staff info
            void viewTeachingStaff()
            {
                //display teaching staff list
                Console.WriteLine("----------------------- Teaching Staff -----------------------");
                int index = 1;
                foreach (var staff in TeachingStaffList)
                {
                    Console.WriteLine("{0}   Name: {1},  subject: {2}",index, staff.Name, staff.Subject);
                    index++;
                }
            }

            Console.WriteLine("Enter any key to exit");
            Console.ReadKey();
        }
    }
}
