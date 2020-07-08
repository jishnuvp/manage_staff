using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel.DataAnnotations;

namespace Staff
{
    class Program
    {
        static void Main(string[] args)
        {
            string check;
            int staffType;

            //list of teaching staff
            List<TeachingStaff> TeachingStaffList = new List<TeachingStaff>();
            //list of administrative staff
            List<AdministrativeStaff> AdministrativeStaffList = new List<AdministrativeStaff>();
            //list of support staff
            List<SupportStaff> SupportStaffList = new List<SupportStaff>();

            void mainMenu()
            {
                // Initial Menu
                int choice;
                Console.WriteLine("\n\n----------------------- Manage Staff -----------------------\n");
                Console.WriteLine("1. Add Staff");
                Console.WriteLine("2. View Staff");
                Console.WriteLine("3. Edit Staff");
                Console.WriteLine("4. Delete Staff");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter your choice(1-4)");
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter a valid number");
                    mainMenu();
                }
                else
                {
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
                        default: mainMenu(); break;
                    }
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
                if(!Int32.TryParse(Console.ReadLine(), out staffType))
                {
                    Console.WriteLine("Enter a valid number");
                    staffType = getStaffType();
                }
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
                        //viewTeachingStaff(flag);
                        deleteTeachingStaff();
                        //viewTeachingStaff(flag);
                        break;
                    case 2:
                        //viewAdministrativeStaff(flag);
                        deleteAdministrativeStaff();
                        //viewAdministrativeStaff(flag);
                        break;
                    case 3:
                        //viewSupportStaff(flag);
                        deleteSupportStaff();
                        //viewSupportStaff(flag);
                        break;
                }
                mainMenu();
            }

            int viewType()
            {
                int choice;
                Console.WriteLine("1. View All");
                Console.WriteLine("2. View Single");
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter a valid number");
                    choice = getStaffType();
                }
                return choice;
            }
            // function to display teaching staff info
            void viewTeachingStaff()
            {
                int index = 1, slNum;
                //display teaching staff list
                Console.WriteLine("\n\n----------------------- Teaching Staff -----------------------\n");
                int choice = viewType();
                switch (choice)
                {
                    case 1:
                        foreach (var staff in TeachingStaffList)
                        {
                            staff.viewStaff(index);
                            index++;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter Sl number of the staff to view");
                        if (!Int32.TryParse(Console.ReadLine(), out slNum))
                        {
                            Console.WriteLine("Enter a valid Sl number");
                            viewTeachingStaff();
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
                                        staff.viewStaff(slNum);
                                    }
                                    index++;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Sl number must be less than or equal to " + TeachingStaffList.Count);
                                viewTeachingStaff();
                            }
                        }
                        break;
                }
            }

            // function to display administrative staff info
            void viewAdministrativeStaff()
            {
                //display administrative staff list
                Console.WriteLine("\n\n----------------------- Administrative Staff -----------------------\n");
                int index = 1, slNum;
                int choice = viewType();
                switch (choice)
                {
                    case 1:
                        foreach (var staff in AdministrativeStaffList)
                        {
                            staff.viewStaff(index);
                            index++;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter Sl number of the staff to view");
                        //int slNum = Convert.ToInt32(Console.ReadLine());
                        if (!Int32.TryParse(Console.ReadLine(), out slNum))
                        {
                            Console.WriteLine("Enter a valid Sl number");
                            viewAdministrativeStaff();
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
                                        staff.viewStaff(slNum);
                                    }
                                    index++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sl number must be less than or equal to " + AdministrativeStaffList.Count);
                                viewAdministrativeStaff();
                            }
                        }
                        break;

                }
            }
            // function to display support staff info
            void viewSupportStaff()
            {
                //display support staff list
                Console.WriteLine("\n\n----------------------- Support Staff -----------------------\n");
                int index = 1, slNum;
                int choice = viewType();
                switch (choice)
                {
                    case 1:
                        foreach (var staff in SupportStaffList)
                        {
                            staff.viewStaff(index);
                            index++;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter Sl number of the staff to view");
                        //int slNum = Convert.ToInt32(Console.ReadLine());
                        if (!Int32.TryParse(Console.ReadLine(), out slNum))
                        {
                            Console.WriteLine("Enter a valid Sl number");
                            viewSupportStaff();
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
                                        staff.viewStaff(slNum);
                                    }
                                    index++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sl number must be less than or equal to " + SupportStaffList.Count);
                                viewSupportStaff();
                            }
                        }
                        break;
                }
            }

            // function to add teaching staff
            void addTeachingStaff()
            {
                do
                {
                    TeachingStaff teachingStaff = new TeachingStaff();
                    teachingStaff.addStaff();
                    TeachingStaffList.Add(teachingStaff);

                    //var context = new ValidationContext(teachingStaff, null, null);
                    //var result = new List<ValidationResult>();
                    //var isValid = Validator.TryValidateObject(teachingStaff, context, result, true);
                    //foreach (var str in result)
                    //{
                    //    Console.WriteLine(str.ErrorMessage.ToString());
                    //}

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
                    AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                    administrativeStaff.addStaff();
                    AdministrativeStaffList.Add(administrativeStaff);
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
                    SupportStaff supportStaff = new SupportStaff();
                    supportStaff.addStaff();
                    SupportStaffList.Add(supportStaff);
                    Console.WriteLine("\nDo you want to add more staff (Y/N) ?");
                    check = Console.ReadLine();
                } while (check == "Y" || check == "y");
            }

            // function to delete teaching staff
            void deleteTeachingStaff()
            {
                int trashedStaff;
                Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
                if (!Int32.TryParse(Console.ReadLine(), out trashedStaff))
                {
                    Console.WriteLine("Enter a valid Sl Number");
                    deleteTeachingStaff();
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
                        deleteTeachingStaff();
                    }
                }
            }

            // function to delete administrative staff
            void deleteAdministrativeStaff()
            {
                int trashedStaff;
                Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
                if (!Int32.TryParse(Console.ReadLine(), out trashedStaff))
                {
                    Console.WriteLine("Enter a valid Sl Number");
                    deleteAdministrativeStaff();
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
                        deleteAdministrativeStaff();
                    }
                }
            }

            // function to delete support staff
            void deleteSupportStaff()
            {
                int trashedStaff;
                Console.WriteLine("\nEnter the Sl number of the staff that you want to delete");
                if (!Int32.TryParse(Console.ReadLine(), out trashedStaff))
                {
                    Console.WriteLine("Enter a valid Sl Number");
                    deleteSupportStaff();
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
                        deleteSupportStaff();
                    }

                }
            }

            // function for update a teaching staff
            void updateTeachingStaff()
            {
                int slNum, index = 1;
                Console.WriteLine("\nEnter the Sl Number of the staff that you want to update");
                if (!Int32.TryParse(Console.ReadLine(), out slNum))
                {
                    Console.WriteLine("Enter a valid Sl Number");
                    updateTeachingStaff();
                }
                else
                {
                    if (TeachingStaffList.Count >= slNum)
                    {
                        foreach (var staff in TeachingStaffList)
                        {
                            if (slNum == index)
                            {
                                staff.viewStaff(slNum);
                                staff.updateStaff();
                            }
                            index++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSl number must be less than or equal to" + TeachingStaffList.Count);
                        updateTeachingStaff();
                    }
                }
                
            }

            // function for update a administrative staff
            void updateAdministrativeStaff()
            {
                int slNum, index = 1;
                Console.WriteLine("\nEnter the Sl Number of the staff");
                if (!Int32.TryParse(Console.ReadLine(), out slNum))
                {
                    Console.WriteLine("Enter a valid Sl Number");
                    updateAdministrativeStaff();
                }
                else
                {
                    if (AdministrativeStaffList.Count >= slNum)
                    {
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
                    else
                    {
                        Console.WriteLine("\nSl number must be less than or equal to" + AdministrativeStaffList.Count);
                        updateAdministrativeStaff();
                    }
                }
            }
            // function for update a support staff
            void updateSupportStaff()
            {
                int slNum, index = 1;
                Console.WriteLine("\nEnter the Sl Number of the staff");
                if (!Int32.TryParse(Console.ReadLine(), out slNum))
                {
                    Console.WriteLine("Enter a valid Sl Number");
                    updateSupportStaff();
                }
                else
                {
                    if (SupportStaffList.Count >= slNum)
                    {
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
                    else
                    {
                        Console.WriteLine("\nSl number must be less than or equal to" + SupportStaffList.Count);
                        updateSupportStaff();
                    }
                }
            }

            Console.WriteLine("\nEnter any key to exit");
            Console.ReadKey();
        }
    }
}
