using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace Staff
{
    class ManageStaff
    {

        public static TextWriter writer = new StreamWriter(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.xml");

        public static int staffTypeChoice, index;

        public static List<Staff> StaffList = new List<Staff>();

        // function to get the user choice
        public static int GetStaffType()
        {
            index = 1;
            foreach (string str in Enum.GetNames(typeof(StaffTypes)))
            {
                Console.WriteLine($"{index}. {str}");
                index++;
            }
            Console.WriteLine($"{index}. Back To Main Menu");
            Console.WriteLine("\nEnter your choice again");
            if (!Int32.TryParse(Console.ReadLine(), out staffTypeChoice))
            {
                Console.WriteLine("\nEnter a valid number");
                staffTypeChoice = GetStaffType();
            }else if(!(staffTypeChoice <= (Enum.GetNames(typeof(StaffTypes)).Length) +1 && staffTypeChoice > 0))
            {
                Console.WriteLine("\nEnter a valid choice");
                staffTypeChoice = GetStaffType();
            }
            return staffTypeChoice;
        }

        // function for add staff
        public void AddStaff()
        {
            staffTypeChoice = GetStaffType();
            var empType = (StaffTypes)staffTypeChoice;
            Console.WriteLine(empType);
            if(staffTypeChoice == index)
            {
                return;
            }
            switch (staffTypeChoice)
            {
                case 1:
                    Console.WriteLine("\n\n----------------------- Teaching Staff -----------------------\n");
                    TeachingStaff teachingStaff = new TeachingStaff();
                    teachingStaff.AddStaff(empType, StaffList);
                    StaffList.Add(teachingStaff);
                    break;
                case 2:
                    Console.WriteLine("\n\n----------------------- Administrative Staff -----------------------\n");
                    AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                    administrativeStaff.AddStaff(empType, StaffList);
                    StaffList.Add(administrativeStaff);
                    break;
                case 3:
                    Console.WriteLine("\n\n----------------------- Support Staff -----------------------\n");
                    SupportStaff supportStaff = new SupportStaff();
                    supportStaff.AddStaff(empType, StaffList);
                    StaffList.Add(supportStaff);
                    break;
                case 4:
                    // back to main menu
                    break;
            }
        }

        // function for view staff

        public void ViewStaff()
        {
            staffTypeChoice = GetStaffType();
            if (staffTypeChoice == index)
            {
                return;
            }
            var filteredList = GetFilteredList(staffTypeChoice);
            Console.WriteLine($"\n\n----------------------- View {(StaffTypes)staffTypeChoice} Staff -----------------------\n");
            int choice = ViewType();
            switch (choice)
            {
                case 1:
                    foreach (var staff in filteredList)
                    {
                        staff.ViewStaff();
                    }
                    break;
                case 2:
                    Console.WriteLine("\nEnter Emp code of the staff to view");
                    string code = Console.ReadLine();
                    code = code.ToUpper();
                    if (filteredList.Exists(x => x.EmpCode == code))
                    {
                        foreach (var staff in filteredList)
                        {
                            if (staff.EmpCode == code)
                            {
                                staff.ViewStaff();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nStaff Not Found");
                        ViewStaff();
                    }
                    break;
            }

        }

        // function for update staff details
        public void UpdateStaff()
        {            
            Console.WriteLine($"\n\n----------------------- Update {(StaffTypes)staffTypeChoice} Staff -----------------------\n");
            Console.WriteLine("\nEnter Emp code of the staff that you want to update");
            string code = Console.ReadLine();
            code = code.ToUpper();
            if (StaffList.Exists(x => x.EmpCode == code))
            {
                foreach (var staff in StaffList)
                {
                    if (staff.EmpCode == code)
                    {
                        staff.ViewStaff();
                        staff.UpdateStaff();
                    }
                }
            }
            else
            {
                Console.WriteLine("\nStaff Not Found");
                UpdateStaff();
            }
        }

        // function for delete a staff
        public void DeleteStaff()
        {
            Console.WriteLine($"\n\n----------------------- Delete {(StaffTypes)staffTypeChoice} Staff -----------------------\n");
            Console.WriteLine("\nEnter Emp code of the staff that you want to delete");
            string code = Console.ReadLine();
            code = code.ToUpper();
            if (StaffList.Exists(x => x.EmpCode == code))
            {
                StaffList.RemoveAll(x => x.EmpCode == code);
                Console.WriteLine($"\nStaff with Emp Code {code} removed succesfully");
            }
            else
            {
                Console.WriteLine("\nStaff Not Found");
                DeleteStaff();
            }
        }

        public static int ViewType()
        {
            int choice;
            Console.WriteLine("\n1. View All");
            Console.WriteLine("2. View Single");
            if (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("\nEnter a valid number");
                choice = GetStaffType();
            }
            return choice;
        }
        public static List<Staff> GetFilteredList(int staffTypeChoice)
        {
            var filteredList = new List<Staff>();
            var empType = (StaffTypes)staffTypeChoice;
            foreach (var staff in StaffList)
            {
                if (staff.StaffType == empType)
                {
                    filteredList.Add(staff);
                }
            }
            return filteredList;
        }
        public static void SerializeData<T>(List<T> list, TextWriter writer)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.xml");
            //XmlRootAttribute root = new XmlRootAttribute("Goals");


            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(writer, list);
        }
    }
}
