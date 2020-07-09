using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel.DataAnnotations;

namespace Staff
{
    class Program
    {
        public static void mainMenu()
        {
            ManageStaff manageStaff = new ManageStaff();
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
                        manageStaff.addStaff();
                        break;
                    case 2:
                        manageStaff.viewStaff();
                        break;
                    case 3:
                        manageStaff.updateStaff();
                        break;
                    case 4:
                        manageStaff.deleteStaff();
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default: mainMenu(); break;
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            mainMenu();     //invoke main menu
            Console.WriteLine("\nEnter any key to exit");
            Console.ReadKey();
        }
    }
}
