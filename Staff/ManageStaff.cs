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

        public static int staffType;

        public static List<Staff> StaffList = new List<Staff>();

        // function to get the user choice
        public static int GetStaffType()
        {
            int index = 1;
            foreach (string str in Enum.GetNames(typeof(StaffTypes)))
            {
                Console.WriteLine($"{index}. {str}");
                index++;
            }
            Console.WriteLine($"{index}. Back To Main Menu");
            Console.WriteLine("Enter your choice again");
            if (!Int32.TryParse(Console.ReadLine(), out staffType))
            {
                Console.WriteLine("Enter a valid number");
                staffType = GetStaffType();
            }
            return staffType;
        }

        // function for add staff
        public void AddStaff()
        {
            staffType = GetStaffType();
            var empType = (StaffTypes)staffType-1;
            switch (staffType)
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
            staffType = GetStaffType();
            var filteredList = GetFilteredList(staffType);
            Console.WriteLine($"\n\n----------------------- View {(StaffTypes)staffType - 1} Staff -----------------------\n");
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
            staffType = GetStaffType();
            var filteredList = GetFilteredList(staffType);
            Console.WriteLine($"\n\n----------------------- Update {(StaffTypes)staffType - 1} Staff -----------------------\n");
            Console.WriteLine("\nEnter Emp code of the staff that you want to update");
            string code = Console.ReadLine();
            if (filteredList.Exists(x => x.EmpCode == code))
            {
                foreach (var staff in filteredList)
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
            staffType = GetStaffType();
            var filteredList = GetFilteredList(staffType);
            Console.WriteLine($"\n\n----------------------- Delete {(StaffTypes)staffType - 1} Staff -----------------------\n");
            Console.WriteLine("\nEnter Emp code of the staff that you want to delete");
            string code = Console.ReadLine();
            if (filteredList.Exists(x => x.EmpCode == code))
            {
                foreach (var staff in filteredList)
                {
                    if (staff.EmpCode == code)
                    {
                        StaffList.Remove(staff);
                        Console.WriteLine($"\nStaff with Emp Code {code} removed succesfully");
                    }
                }
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
            Console.WriteLine("1. View All");
            Console.WriteLine("2. View Single");
            if (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Enter a valid number");
                choice = GetStaffType();
            }
            return choice;
        }
        public static List<Staff> GetFilteredList(int staffType)
        {
            var filteredList = new List<Staff>();
            var empType = (StaffTypes)staffType - 1;
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
