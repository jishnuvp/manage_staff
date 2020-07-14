﻿using System;
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
                        manageStaff.AddStaff();
                        break;
                    case 2:
                        manageStaff.ViewStaff();
                        break;
                    case 3:
                        manageStaff.UpdateStaff();
                        break;
                    case 4:
                        manageStaff.DeleteStaff();
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default: mainMenu(); break;
                }
                mainMenu();
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            mainMenu();     //invoke main menu

        }
    }
}
