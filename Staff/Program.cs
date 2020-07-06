using System;
using System.Collections.Generic;

namespace Staff
{
    class Program
    {
        static void Main(string[] args)
        {
            string check;
            int staffType;
            bool flag = false;

            //list of teaching staff
            TeachingStaff teachingStaff = new TeachingStaff();
            List<TeachingStaff> TeachingStaffList = new List<TeachingStaff>();

            //adding values to teaching staff object list
            TeachingStaffList.Add(new TeachingStaff("Jishnu", "Malayalam", "9999999999", "04-05-2020"));
            TeachingStaffList.Add(new TeachingStaff("Surya dev", "Hindi", "8888888888", "24-03-2020"));
            TeachingStaffList.Add(new TeachingStaff("Vishnu", "Mathematics", "7777777777", "07-05-2020"));
            TeachingStaffList.Add(new TeachingStaff("Vijay", "English", "9898989898", "06-05-2020"));

            //list of administrative staff
            AdministrativeStaff administrativeStaff = new AdministrativeStaff();
            List<AdministrativeStaff> AdministrativeStaffList = new List<AdministrativeStaff>();

            //adding values to administrative staff object list
            AdministrativeStaffList.Add(new AdministrativeStaff("Jishnu", "Manager", "9999999999", "04-05-2020"));
            AdministrativeStaffList.Add(new AdministrativeStaff("James", "Principal", "8888888888", "06-05-2020"));
            AdministrativeStaffList.Add(new AdministrativeStaff("John", "Super visor", "9898989898", "05-05-2020"));

            //list of support staff
            SupportStaff supportStaff = new SupportStaff();
            List<SupportStaff> SupportStaffList = new List<SupportStaff>();

            //adding values to support staff object list
            SupportStaffList.Add(new SupportStaff("Jishnu", "Principal office", "9999999999", "04-05-2020"));
            SupportStaffList.Add(new SupportStaff("James", "Staff Room", "8888888888", "06-05-2020"));
            SupportStaffList.Add(new SupportStaff("John", "Store", "9898989898", "05-05-2020"));

            void mainMenu()
            {
                // Initial Menu

                Console.WriteLine("\n\n----------------------- Manage Staff -----------------------\n");
                Console.WriteLine("1. Add Staff");
                Console.WriteLine("2. View Staff");
                Console.WriteLine("3. Edit Staff");
                Console.WriteLine("4. Delete Staff");
                Console.WriteLine("5. Exit");

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
                    case 5:
                        System.Environment.Exit(0);
                        break;
                }
            }

            mainMenu();     //invoke main menu


            // function to get the user choice
            int getStaffType()
            {
                Console.WriteLine("\n\n1. Teaching Staff");
                Console.WriteLine("2. Administrative Staff");
                Console.WriteLine("3. Support Staff");
                Console.WriteLine("4. Back Home");
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
                        mainMenu();
                        break;
                }
                mainMenu();
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
                    case 2:
                        viewAdministrativeStaff();
                        break;
                    case 3:
                        viewSupportStaff();
                        break;
                }

                mainMenu();
            }

            // function for update staff details
            void UpdateStaff()
            {
                staffType = getStaffType();
                switch (staffType)
                {
                    case 1:
                        updateTeachingStaff();
                        break;
                    case 2:
                        updateAdministrativeStaff();
                        break;
                    case 3:
                        updateSupportStaff();
                        break;
                }
                mainMenu();
            }

            // function for delete a staff
            void DeleteStaff()
            {
                staffType = getStaffType();
                switch (staffType)
                {
                    case 1:
                        viewTeachingStaff(flag);
                        deleteTeachingStaff();
                        viewTeachingStaff(flag);
                        break;
                    case 2:
                        viewAdministrativeStaff(flag);
                        deleteAdministrativeStaff();
                        viewAdministrativeStaff(flag);
                        break;
                    case 3:
                        viewSupportStaff(flag);
                        deleteSupportStaff();
                        viewSupportStaff(flag);
                        break;
                }
                mainMenu();
            }

            // function to display teaching staff info
            void viewTeachingStaff(bool flag = true)
            {
                //display teaching staff list
                Console.WriteLine("\n\n----------------------- Teaching Staff -----------------------\n");
                int index = 1;
                foreach (var staff in TeachingStaffList)
                {
                    staff.viewStaff(index);
                    index++;
                }
                if (flag)
                {
                    Console.WriteLine("\nEnter Sl number of the staff to view");
                    int slNum = Convert.ToInt32(Console.ReadLine());
                    if (TeachingStaffList.Count >= slNum)
                    {
                        index = 1;
                        foreach (var staff in TeachingStaffList)
                        {
                            if (slNum == index)
                            {
                                staff.viewStaff(slNum);
                            }
                            index++;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Enter valid Sl number");
                    }
                }
            }

            // function to display administrative staff info
            void viewAdministrativeStaff(bool flag = true)
            {
                //display administrative staff list
                Console.WriteLine("\n\n----------------------- Administrative Staff -----------------------\n");
                int index = 1;
                foreach (var staff in AdministrativeStaffList)
                {
                    staff.viewStaff(index);
                    index++;
                }
                if (flag)
                {
                    Console.WriteLine("\nEnter Sl number of the staff to view");
                    int slNum = Convert.ToInt32(Console.ReadLine());
                    if (AdministrativeStaffList.Count >= slNum)
                    {
                        index = 1;
                        foreach (var staff in AdministrativeStaffList)
                        {
                            if (slNum == index)
                            {
                                staff.viewStaff(slNum);
                            }
                            index++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter valid Sl number");
                    }
                }
            }
            // function to display support staff info
            void viewSupportStaff(bool flag = true)
            {
                //display support staff list
                Console.WriteLine("\n\n----------------------- Support Staff -----------------------\n");
                int index = 1;
                foreach (var staff in SupportStaffList)
                {
                    staff.viewStaff(index);
                    index++;
                }
                if (flag)
                {
                    Console.WriteLine("\nEnter Sl number of the staff to view");
                    int slNum = Convert.ToInt32(Console.ReadLine());
                    if (AdministrativeStaffList.Count >= slNum)
                    {
                        index = 1;
                        foreach (var staff in SupportStaffList)
                        {
                            if (slNum == index)
                            {
                                staff.viewStaff(slNum);
                            }
                            index++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter valid Sl number");
                    }
                }
            }

            // function to add teaching staff
            void addTeachingStaff()
            {
                do
                {
                    teachingStaff.addStaff();
                    TeachingStaffList.Add(new TeachingStaff(teachingStaff.Name, teachingStaff.Subject, teachingStaff.ContactNumber, teachingStaff.DateOfJoin));
                    Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                    check = Console.ReadLine();
                } while (check == "Y" || check == "y");
            }

            // function to add administrative staff
            void addAdministrativeStaff()
            {
                Console.WriteLine("\n\n----------------------- Add Administrative Staff -----------------------\n");
                do
                {
                    administrativeStaff.addStaff();
                    AdministrativeStaffList.Add(new AdministrativeStaff(administrativeStaff.Name, administrativeStaff.Role, administrativeStaff.ContactNumber, administrativeStaff.DateOfJoin));
                    Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                    check = Console.ReadLine();
                } while (check == "Y" || check == "y");
            }

            // function to add support staff
            void addSupportStaff()
            {
                Console.WriteLine("\n\n----------------------- Add Support Staff -----------------------\n");
                do
                {
                    supportStaff.addStaff();
                    SupportStaffList.Add(new SupportStaff(supportStaff.Name, supportStaff.Department, supportStaff.ContactNumber, supportStaff.DateOfJoin));
                    Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                    check = Console.ReadLine();
                } while (check == "Y" || check == "y");
            }

            // function to delete teaching staff
            void deleteTeachingStaff()
            {
                int trashedStaff;
                Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
                trashedStaff = Convert.ToInt32(Console.ReadLine());
                if (TeachingStaffList.Count >= trashedStaff)
                {
                    TeachingStaffList.RemoveAt(trashedStaff - 1);
                    Console.WriteLine($"{trashedStaff} succesfully deleted");
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid Sl number");
                }
            }

            // function to delete administrative staff
            void deleteAdministrativeStaff()
            {
                int trashedStaff;
                Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
                trashedStaff = Convert.ToInt32(Console.ReadLine());
                if (AdministrativeStaffList.Count >= trashedStaff)
                {
                    AdministrativeStaffList.RemoveAt(trashedStaff - 1);
                    Console.WriteLine($"{trashedStaff} succesfully deleted");
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid Sl number");
                }
            }

            // function to delete support staff
            void deleteSupportStaff()
            {
                int trashedStaff;
                Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
                trashedStaff = Convert.ToInt32(Console.ReadLine());
                if (SupportStaffList.Count >= trashedStaff)
                {
                    SupportStaffList.RemoveAt(trashedStaff - 1);
                    Console.WriteLine($"{trashedStaff} succesfully deleted");
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid Sl number");
                }
            }

            // function for update a teaching staff
            void updateTeachingStaff()
            {
                viewTeachingStaff(flag);
                Console.WriteLine("\nEnter the Sl Number of the staff");
                int slNum = Convert.ToInt32(Console.ReadLine());
                int index = 1;
                foreach (var staff in TeachingStaffList)
                {
                    if(slNum == index)
                    {
                        staff.viewStaff(slNum);
                        staff.updateStaff();
                    }
                    index++;
                }
            }

            // function for update a administrative staff
            void updateAdministrativeStaff()
            {
                viewAdministrativeStaff(flag);
                Console.WriteLine("\nEnter the Sl Number of the staff");
                int slNum = Convert.ToInt32(Console.ReadLine());
                int index = 1;
                foreach (var staff in AdministrativeStaffList)
                {
                    if (slNum == index)
                    {
                        staff.viewStaff(slNum);
                        staff.updateStaff();
                    }
                    index++;
                }
            }
            // function for update a support staff
            void updateSupportStaff()
            {
                viewSupportStaff(flag);
                Console.WriteLine("\nEnter the Sl Number of the staff");
                int slNum = Convert.ToInt32(Console.ReadLine());
                int index = 1;
                foreach (var staff in SupportStaffList)
                {
                    if (slNum == index)
                    {
                        staff.viewStaff(slNum);
                        staff.updateStaff();
                    }
                    index++;
                }
            }

            Console.WriteLine("\nEnter any key to exit");
            Console.ReadKey();
        }
    }
}
