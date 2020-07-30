using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using StaffLibrary;
using StaffLibrary.DbManager;

namespace StaffConsole
{
    public class ManageStaff
    {
        public static int staffTypeChoice, counter;

        public static string code, name, number, subj, role, department;
        public static DateTime doj;

        // function for add staff
        public void AddStaff()
        {
            List<Staff> StaffList = new List<Staff>();
            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed, flag = false, isCodeExist = false;
            int index = 1, choice;
            string addMoreChoice;

            DataBaseManager dbManager = new DataBaseManager();
            do
            {
                staffTypeChoice = GetStaffType();
                var empType = (StaffTypes)staffTypeChoice;
                if (staffTypeChoice == counter)
                {
                    return;
                }

                Console.WriteLine($"\n\n----------------------- {empType} Staff -----------------------\n");
                do
                {
                    succeed = false;
                    try
                    {
                        Console.WriteLine("\nEnter Name: ");
                        name = Console.ReadLine();
                        Validator.ValidateName(name);
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
                    code = code.ToUpper();
                    isCodeExist = dbManager.CheckCodeExistence(code);
                    if (isCodeExist || StaffList.Exists(x => x.EmpCode == code))
                    {
                        Console.WriteLine("\nEmp code already exists");
                        succeed = false;
                    }
                    else
                    {
                        succeed = true;
                    }
                } while (succeed == false);


                do
                {
                    succeed = false;
                    try
                    {
                        Console.WriteLine("\nEnter Contact Number");
                        number = Console.ReadLine();
                        Validator.ValidatePhoneNumber(number);
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
                        doj = DateTime.Parse(Console.ReadLine());
                        Validator.ValidateDate(doj);
                        succeed = true;

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                } while (succeed == false);


                switch (staffTypeChoice)
                {
                    case 1:
                        do
                        {
                            succeed = false;
                            index = 1;
                            try
                            {
                                Console.WriteLine("\nSelect your choice");
                                foreach (string item in subjects)
                                {
                                    Console.WriteLine($"{index}. {item}");
                                    index++;
                                }
                                if (!Int32.TryParse(Console.ReadLine(), out choice))
                                {
                                    succeed = false;
                                    Console.WriteLine("Enter a valid choice");
                                }
                                else
                                {
                                    if (choice <= subjects.Length && choice > 0)
                                    {
                                        subj = subjects[choice - 1];
                                        succeed = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a valid choice");
                                        succeed = false;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (succeed == false);

                        TeachingStaff teachingStaff = new TeachingStaff(name, code, empType, subj, number, doj);
                        StaffList.Add(teachingStaff);
                        //dbManager.AddStaff<TeachingStaff>(teachingStaff);
                        break;

                    case 2:
                        do
                        {
                            succeed = false;
                            try
                            {
                                Console.WriteLine("\nEnter Role");
                                role = Console.ReadLine();
                                succeed = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (succeed == false);
                        AdministrativeStaff administrativeStaff = new AdministrativeStaff(name, code, empType, role, number, doj);
                        StaffList.Add(administrativeStaff);
                        //dbManager.AddStaff<AdministrativeStaff>(administrativeStaff);
                        break;

                    case 3:
                        do
                        {
                            succeed = false;
                            try
                            {
                                Console.WriteLine("\nEnter Department");
                                department = Console.ReadLine();
                                succeed = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (succeed == false);
                        SupportStaff supportStaff = new SupportStaff(name, code, empType, department, number, doj);
                        StaffList.Add(supportStaff);
                        //dbManager.AddStaff<SupportStaff>(supportStaff);
                        break;
                    case 4:
                        // back to main menu
                        break;
                }
                Console.WriteLine("Do you want to add more ? (Y/N)");
                addMoreChoice = Console.ReadLine();
            } while (addMoreChoice == "y" || addMoreChoice == "Y");
            dbManager.AddStaffToType(StaffList);
        }

        // function for view staff

        public void ViewStaff()
        {
            DataBaseManager dataBaseManager = new DataBaseManager();
            staffTypeChoice = GetStaffType();
            if (staffTypeChoice == counter)
            {
                return;
            }
            //var filteredList = GetFilteredList(staffTypeChoice);
            List<Staff> filteredList = new List<Staff>();
            Console.WriteLine($"\n\n----------------------- View {(StaffTypes)staffTypeChoice} Staff -----------------------\n");
            int choice = ViewType();
            switch (choice)
            {
                case 1:
                    filteredList = dataBaseManager.FetchStaffByCategory((StaffTypes)staffTypeChoice);
                    foreach (var staff in filteredList)
                    {
                        ViewStaffInfo(staff);
                    }
                    filteredList.Clear();
                    break;
                case 2:
                    Console.WriteLine("\nEnter Emp code of the staff to view");
                    string code = Console.ReadLine();
                    code = code.ToUpper();
                    filteredList = dataBaseManager.FetchSingleStaffByType(code, (StaffTypes)staffTypeChoice);
                    if (filteredList.Exists(x => x.EmpCode == code))
                    {
                        foreach (var staff in filteredList)
                        {
                            if (staff.EmpCode == code)
                            {
                                ViewStaffInfo(staff);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nStaff Not Found");
                        ViewStaff();
                    }
                    break;
                case 3:
                    //FetchSeniorStaff();
                    filteredList.Clear();
                    filteredList = dataBaseManager.FetchSeniorStaff((StaffTypes)staffTypeChoice);
                    foreach (var staff in filteredList)
                    {
                        ViewStaffInfo(staff);
                    }
                    break;
                default: return;
            }
           


        }

        public static void ViewStaffInfo(Staff staff)
        {
            switch (staffTypeChoice)
            {
                case 1:
                    TeachingStaff teachingStaff = (TeachingStaff)staff;
                    Console.WriteLine("\n\n{0}   Name: {1}, Type: {2},  Subject: {3},   Contact Number: {4},   Joining Date: {5}", teachingStaff.EmpCode, teachingStaff.Name, teachingStaff.StaffType, teachingStaff.Subject, teachingStaff.ContactNumber, teachingStaff.DateOfJoin);
                    break;
                case 2:
                    AdministrativeStaff administrativeStaff = (AdministrativeStaff)staff;
                    Console.WriteLine("\n\n{0}   Name: {1}, Type: {2},  Role: {3},   Contact Number: {4},   Joining Date: {5}", administrativeStaff.EmpCode, administrativeStaff.Name, administrativeStaff.StaffType, administrativeStaff.Role, administrativeStaff.ContactNumber, administrativeStaff.DateOfJoin);
                    break;
                case 3:
                    SupportStaff supportStaff = (SupportStaff)staff;
                    Console.WriteLine("\n\n{0}   Name: {1}, Type: {2},  Department: {3},   Contact Number: {4},   Joining Date: {5}", supportStaff.EmpCode, supportStaff.Name, supportStaff.StaffType, supportStaff.Department, supportStaff.ContactNumber, supportStaff.DateOfJoin);
                    break;
                default: return;
            }
        }

        // function for update staff details
        public void UpdateStaff()
        {
            DataBaseManager dataBaseManager = new DataBaseManager();

            DateTime dateInput;
            bool succeed;
            string input;
            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            int index = 1, choice;

            Console.WriteLine($"\n\n----------------------- Update Staff -----------------------\n");
            Console.WriteLine("\nEnter Emp code of the staff that you want to update");
            string code = Console.ReadLine();
            code = code.ToUpper();

            List<Staff> filteredList = new List<Staff>();

            filteredList = dataBaseManager.FetchStaffInfo(code);
            if (filteredList.Exists(x => x.EmpCode == code))
            {
                foreach (var staff in filteredList)
                {
                    if (staff.EmpCode == code)
                    {
                        //ViewStaffInfo(staff);
                        do
                        {
                            succeed = false;
                            try
                            {
                                Console.WriteLine($"Enter Name ({staff.Name})");
                                input = Console.ReadLine();
                                if (string.IsNullOrEmpty(input))
                                {
                                    name = staff.Name;

                                }
                                else
                                {
                                    name = input;
                                    Validator.ValidateName(name);
                                }
                                succeed = true;
                                staff.Name = name;
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
                                Console.WriteLine($"\nEnter Contact Number ({staff.ContactNumber})");
                                input = Console.ReadLine();
                                if (string.IsNullOrEmpty(input))
                                {
                                    number = staff.ContactNumber;

                                }
                                else
                                {
                                    number = input;
                                    Validator.ValidatePhoneNumber(number);
                                }
                                succeed = true;
                                staff.ContactNumber = number;
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
                                Console.WriteLine($"\nEnter Date of Join ({staff.DateOfJoin}) (dd-mm-yyyy) ");
                                if (!(DateTime.TryParse(Console.ReadLine(), out dateInput)))
                                {
                                    doj = staff.DateOfJoin;
                                }
                                else
                                {
                                    doj = dateInput;
                                    Validator.ValidateDate(doj);
                                }

                                succeed = true;
                                staff.DateOfJoin = doj;
                                Console.WriteLine("Date of Join updated succesfully");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (succeed == false);

                        string staffType = staff.StaffType.ToString();
                        switch (staffType)
                        {
                            case "Teaching":
                                TeachingStaff teachingStaff = (TeachingStaff)staff;
                                do
                                {
                                    succeed = false;
                                    index = 1;
                                    try
                                    {
                                        Console.WriteLine($"\nSelect language from choice ({teachingStaff.Subject})");
                                        foreach (string item in subjects)
                                        {
                                            Console.WriteLine($"{index}. {item}");
                                            index++;
                                        }
                                        if (!Int32.TryParse(Console.ReadLine(), out choice))
                                        {
                                            succeed = false;
                                            Console.WriteLine("Enter a valid choice");
                                        }
                                        else
                                        {
                                            if (choice <= subjects.Length && choice > 0)
                                            {
                                                subj = subjects[choice - 1];
                                                succeed = true;
                                                teachingStaff.Subject = subj;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter a valid choice");
                                                succeed = false;
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                } while (succeed == false);
                                dataBaseManager.UpdateStaff<TeachingStaff>(teachingStaff);
                                break;
                            case "Administrative":
                                AdministrativeStaff administrativeStaff = (AdministrativeStaff)staff;
                                do
                                {
                                    succeed = false;
                                    try
                                    {
                                        Console.WriteLine($"\nEnter Role ({administrativeStaff.Role}) ");
                                        input = Console.ReadLine();
                                        if (string.IsNullOrEmpty(input))
                                        {
                                            role = administrativeStaff.Role;

                                        }
                                        else
                                        {
                                            role = input;
                                            Validator.ValidateRole(role);
                                        }
                                        succeed = true;
                                        administrativeStaff.Role = role;
                                        Console.WriteLine("Role updated succesfully");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                } while (succeed == false);
                                dataBaseManager.UpdateStaff<AdministrativeStaff>(administrativeStaff);
                                break;
                            case "Support":
                                SupportStaff supportStaff = (SupportStaff)staff;
                                do
                                {
                                    succeed = false;
                                    try
                                    {
                                        Console.WriteLine($"\nEnter Department ({supportStaff.Department}) ");
                                        input = Console.ReadLine();
                                        if (string.IsNullOrEmpty(input))
                                        {
                                            department = supportStaff.Department;

                                        }
                                        else
                                        {
                                            department = input;
                                            Validator.ValidateDepartment(department);
                                        }
                                        succeed = true;
                                        supportStaff.Department = department;
                                        Console.WriteLine("Role updated succesfully");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                } while (succeed == false);
                                dataBaseManager.UpdateStaff<SupportStaff>(supportStaff);
                                break;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("\nStaff Not Found");
                return;
            }
        }

        // function for delete a staff
        public void DeleteStaff()
        {
            DataBaseManager dataBaseManager = new DataBaseManager();
            Console.WriteLine($"\n\n----------------------- Delete {(StaffTypes)staffTypeChoice} Staff -----------------------\n");
            Console.WriteLine("\nEnter Emp code of the staff that you want to delete");
            string code = Console.ReadLine();
            code = code.ToUpper();
            var flag = dataBaseManager.DeleteStaff(code);
            if (flag)
            {
                Console.WriteLine($"\nStaff with Emp Code {code} removed succesfully");
            }
            else
            {
                Console.WriteLine("\nStaff Not Found");
                return;
            }
        }

        public static int ViewType()
        {
            int choice;
            Console.WriteLine("\n1. View All");
            Console.WriteLine("2. View Single");
            Console.WriteLine("3. View Senior Staffs");
            if (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("\nEnter a valid number");
                choice = ViewType();
            }
            return choice;
        }

        // function to get the user choice
        public static int GetStaffType()
        {
            counter = 1;
            Console.WriteLine("\n\n");
            foreach (string str in Enum.GetNames(typeof(StaffTypes)))
            {
                Console.WriteLine($"{counter}. {str}");
                counter++;
            }
            Console.WriteLine($"{counter}. Back To Main Menu");
            Console.WriteLine("\nEnter your choice again");
            if (!Int32.TryParse(Console.ReadLine(), out staffTypeChoice))
            {
                Console.WriteLine("\nEnter a valid number");
                staffTypeChoice = GetStaffType();
            }
            else if (!(staffTypeChoice <= (Enum.GetNames(typeof(StaffTypes)).Length) + 1 && staffTypeChoice > 0))
            {
                Console.WriteLine("\nEnter a valid choice");
                staffTypeChoice = GetStaffType();
            }
            return staffTypeChoice;
        }

    }
}
