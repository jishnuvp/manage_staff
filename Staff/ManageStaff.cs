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

        public static string check;
        public static int staffType;
        //list of teaching staff
        public static List<TeachingStaff> TeachingStaffList = new List<TeachingStaff>();
        //list of administrative staff
        public static List<AdministrativeStaff> AdministrativeStaffList = new List<AdministrativeStaff>();
        //list of support staff
        public static List<SupportStaff> SupportStaffList = new List<SupportStaff>();

        // function to get the user choice
        public static int GetStaffType()
        {
            Console.WriteLine("\n\n1. Teaching Staff");
            Console.WriteLine("2. Administrative Staff");
            Console.WriteLine("3. Support Staff");
            Console.WriteLine("4. Back Home");
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
            switch (staffType)
            {
                case 1:
                    // add teaching staff
                    addTeachingStaff();
                    break;
                case 2:
                    // add administrative staff
                    addAdministrativeStaff();
                    break;
                case 3:
                    // add support staff
                    addSupportStaff();
                    break;
                case 4:
                    // back to main menu
                    break;
            }
            Program.mainMenu();
        }

        // function for view staff

        public void ViewStaff()
        {
            staffType = GetStaffType();
            switch (staffType)
            {
                case 1:
                    ViewTeachingStaff();
                    break;
                case 2:
                    ViewAdministrativeStaff();
                    break;
                case 3:
                    ViewSupportStaff();
                    break;
            }
            Program.mainMenu();

        }

        // function for update staff details
        public void UpdateStaff()
        {
            staffType = GetStaffType();
            switch (staffType)
            {
                case 1:
                    UpdateTeachingStaff();
                    break;
                case 2:
                    UpdateAdministrativeStaff();
                    break;
                case 3:
                    UpdateSupportStaff();
                    break;
            }
            Program.mainMenu();
        }

        // function for delete a staff
        public void DeleteStaff()
        {
            staffType = GetStaffType();
            switch (staffType)
            {
                case 1:
                    DeleteTeachingStaff();
                    break;
                case 2:
                    DeleteAdministrativeStaff();
                    break;
                case 3:
                    DeleteSupportStaff();
                    break;
            }
            Program.mainMenu();
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
        // function to display teaching staff info
        public static void ViewTeachingStaff()
        {
            int index = 1, slNum;
            //display teaching staff list
            Console.WriteLine("\n\n----------------------- Teaching Staff -----------------------\n");
            int choice = ViewType();
            switch (choice)
            {
                case 1:
                    foreach (var staff in TeachingStaffList)
                    {
                        staff.ViewStaff(index);
                        index++;
                    }
                    break;
                case 2:
                    Console.WriteLine("\nEnter Sl number of the staff to view");
                    if (!Int32.TryParse(Console.ReadLine(), out slNum))
                    {
                        Console.WriteLine("Enter a valid Sl number");
                        ViewTeachingStaff();
                    }
                    else
                    {
                        if (TeachingStaffList.Count >= slNum)
                        {
                            index = 1;
                            foreach (var staff in TeachingStaffList)
                            {
                                if (slNum == index)
                                {
                                    staff.ViewStaff(slNum);
                                }
                                index++;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Sl number must be less than or equal to " + TeachingStaffList.Count);
                            ViewTeachingStaff();
                        }
                    }
                    break;
            }
        }

        // function to display administrative staff info
        public static void ViewAdministrativeStaff()
        {
            //display administrative staff list
            Console.WriteLine("\n\n----------------------- Administrative Staff -----------------------\n");
            int index = 1, slNum;
            int choice = ViewType();
            switch (choice)
            {
                case 1:
                    foreach (var staff in AdministrativeStaffList)
                    {
                        staff.ViewStaff(index);
                        index++;
                    }
                    break;
                case 2:
                    Console.WriteLine("\nEnter Sl number of the staff to view");
                    //int slNum = Convert.ToInt32(Console.ReadLine());
                    if (!Int32.TryParse(Console.ReadLine(), out slNum))
                    {
                        Console.WriteLine("Enter a valid Sl number");
                        ViewAdministrativeStaff();
                    }
                    else
                    {
                        if (AdministrativeStaffList.Count >= slNum)
                        {
                            index = 1;
                            foreach (var staff in AdministrativeStaffList)
                            {
                                if (slNum == index)
                                {
                                    staff.ViewStaff(slNum);
                                }
                                index++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sl number must be less than or equal to " + AdministrativeStaffList.Count);
                            ViewAdministrativeStaff();
                        }
                    }
                    break;

            }
        }
        // function to display support staff info
        public static void ViewSupportStaff()
        {
            //display support staff list
            Console.WriteLine("\n\n----------------------- Support Staff -----------------------\n");
            int index = 1, slNum;
            int choice = ViewType();
            switch (choice)
            {
                case 1:
                    foreach (var staff in SupportStaffList)
                    {
                        staff.ViewStaff(index);
                        index++;
                    }
                    break;
                case 2:
                    Console.WriteLine("\nEnter Sl number of the staff to view");
                    //int slNum = Convert.ToInt32(Console.ReadLine());
                    if (!Int32.TryParse(Console.ReadLine(), out slNum))
                    {
                        Console.WriteLine("Enter a valid Sl number");
                        ViewSupportStaff();
                    }
                    else
                    {
                        if (AdministrativeStaffList.Count >= slNum)
                        {
                            index = 1;
                            foreach (var staff in SupportStaffList)
                            {
                                if (slNum == index)
                                {
                                    staff.ViewStaff(slNum);
                                }
                                index++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sl number must be less than or equal to " + SupportStaffList.Count);
                            ViewSupportStaff();
                        }
                    }
                    break;
            }
        }


        public static void SerializeData <T>(List<T> list, TextWriter writer)
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(writer, list);
        }



        // function to add teaching staff
        public static void addTeachingStaff()
        {
            Console.WriteLine("\n\n----------------------- Add Teaching Staff -----------------------\n");
            do
            {
                TeachingStaff teachingStaff = new TeachingStaff();
                teachingStaff.AddStaff();
                TeachingStaffList.Add(teachingStaff);
                Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                check = Console.ReadLine();
            } while (check == "Y" || check == "y");
            SerializeData(TeachingStaffList, writer);
        }

        // function to add administrative staff
        public static void addAdministrativeStaff()
        {
            Console.WriteLine("\n\n----------------------- Add Administrative Staff -----------------------\n");
            do
            {
                AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                administrativeStaff.AddStaff();
                AdministrativeStaffList.Add(administrativeStaff);
                Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                check = Console.ReadLine();
            } while (check == "Y" || check == "y");
            SerializeData(AdministrativeStaffList, writer);
        }

        // function to add support staff
        public static void addSupportStaff()
        {
            Console.WriteLine("\n\n----------------------- Add Support Staff -----------------------\n");
            do
            {
                SupportStaff supportStaff = new SupportStaff();
                supportStaff.AddStaff();
                SupportStaffList.Add(supportStaff);
                Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                check = Console.ReadLine();
            } while (check == "Y" || check == "y");
            SerializeData(SupportStaffList, writer);
        }

        // function to delete teaching staff
        public static void DeleteTeachingStaff()
        {
            int trashedStaff;
            Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
            if (!Int32.TryParse(Console.ReadLine(), out trashedStaff))
            {
                Console.WriteLine("Enter a valid Sl Number");
                DeleteTeachingStaff();
            }
            else
            {

                if (TeachingStaffList.Count >= trashedStaff)
                {
                    TeachingStaffList.RemoveAt(trashedStaff - 1);
                    Console.WriteLine($"{trashedStaff} succesfully deleted");
                }
                else
                {
                    Console.WriteLine("\nSl number must be less than or equal to " + TeachingStaffList.Count);
                    DeleteTeachingStaff();
                }
            }
        }

        // function to delete administrative staff
        public static void DeleteAdministrativeStaff()
        {
            int trashedStaff;
            Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
            if (!Int32.TryParse(Console.ReadLine(), out trashedStaff))
            {
                Console.WriteLine("Enter a valid Sl Number");
                DeleteAdministrativeStaff();
            }
            else
            {
                if (AdministrativeStaffList.Count >= trashedStaff)
                {
                    AdministrativeStaffList.RemoveAt(trashedStaff - 1);
                    Console.WriteLine($"{trashedStaff} succesfully deleted");
                }
                else
                {
                    Console.WriteLine("\nSl number must be less than or equal to " + AdministrativeStaffList.Count);
                    DeleteAdministrativeStaff();
                }
            }
        }

        // function to delete support staff
        public static void DeleteSupportStaff()
        {
            int trashedStaff;
            Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
            if (!Int32.TryParse(Console.ReadLine(), out trashedStaff))
            {
                Console.WriteLine("Enter a valid Sl Number");
                DeleteSupportStaff();
            }
            else
            {
                if (SupportStaffList.Count >= trashedStaff)
                {
                    SupportStaffList.RemoveAt(trashedStaff - 1);
                    Console.WriteLine($"{trashedStaff} succesfully deleted");
                }
                else
                {
                    Console.WriteLine("\nSl number must be less than or equal to " + SupportStaffList.Count);
                    DeleteSupportStaff();
                }

            }
        }

        // function for update a teaching staff
        public static void UpdateTeachingStaff()
        {
            int slNum, index = 1;
            Console.WriteLine("\nEnter the Sl Number of the staff that you want to update");
            if (!Int32.TryParse(Console.ReadLine(), out slNum))
            {
                Console.WriteLine("Enter a valid Sl Number");
                UpdateTeachingStaff();
            }
            else
            {
                if (TeachingStaffList.Count >= slNum)
                {
                    foreach (var staff in TeachingStaffList)
                    {
                        if (slNum == index)
                        {
                            staff.ViewStaff(slNum);
                            staff.UpdateStaff();
                        }
                        index++;
                    }
                }
                else
                {
                    Console.WriteLine("\nSl number must be less than or equal to" + TeachingStaffList.Count);
                    UpdateTeachingStaff();
                }
            }

        }

        // function for update a administrative staff
        public static void UpdateAdministrativeStaff()
        {
            int slNum, index = 1;
            Console.WriteLine("\nEnter the Sl Number of the staff");
            if (!Int32.TryParse(Console.ReadLine(), out slNum))
            {
                Console.WriteLine("Enter a valid Sl Number");
                UpdateAdministrativeStaff();
            }
            else
            {
                if (AdministrativeStaffList.Count >= slNum)
                {
                    foreach (var staff in AdministrativeStaffList)
                    {
                        if (slNum == index)
                        {
                            staff.ViewStaff(slNum);
                            staff.UpdateStaff();
                        }
                        index++;
                    }

                }
                else
                {
                    Console.WriteLine("\nSl number must be less than or equal to" + AdministrativeStaffList.Count);
                    UpdateAdministrativeStaff();
                }
            }
        }
        // function for update a support staff
        public static void UpdateSupportStaff()
        {
            int slNum, index = 1;
            Console.WriteLine("\nEnter the Sl Number of the staff");
            if (!Int32.TryParse(Console.ReadLine(), out slNum))
            {
                Console.WriteLine("Enter a valid Sl Number");
                UpdateSupportStaff();
            }
            else
            {
                if (SupportStaffList.Count >= slNum)
                {
                    foreach (var staff in SupportStaffList)
                    {
                        if (slNum == index)
                        {
                            staff.ViewStaff(slNum);
                            staff.UpdateStaff();
                        }
                        index++;
                    }

                }
                else
                {
                    Console.WriteLine("\nSl number must be less than or equal to" + SupportStaffList.Count);
                    UpdateSupportStaff();
                }
            }
        }
    }
}
