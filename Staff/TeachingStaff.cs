﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

//public enum SubjectEnum { malayalam, english, maths, social, science, hindi };


namespace Staff
{
    class TeachingStaff : Staff
    {
        private string subject;

        //properties
        public string Subject
        {
            get { return subject; }
            set {
                subject = value; 
            }
        }

        public void AddStaff()
        {
            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed;
            int index = 1, choice;
            Console.WriteLine("----------------------- Add Teaching Staff -----------------------");
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
                        if(choice <= subjects.Length && choice > 0)
                        {
                            Subject = subjects[choice-1];
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

        public void ViewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1},  Subject: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Subject, ContactNumber, DateOfJoin);
        }

        public void UpdateStaff()
        {
            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed;
            int choice, index;
            Console.WriteLine("\nSelect the field that you want to update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Subject");
            Console.WriteLine("3. Contact Number");
            Console.WriteLine("4. Joined Date");
            Console.WriteLine("5. Back to Home\n");
            if (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Enter a valid Sl Number");
                return;
            }
            switch (choice)
            {
                case 1:
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
                    Console.WriteLine("Name updated succesfully");
                    break;
                case 2:
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
                                    Subject = subjects[choice - 1];
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
                    Console.WriteLine("Subject updated succesfully");
                    break;
                case 3:
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
                    Console.WriteLine("Contact number updated succesfully");
                    break;
                case 4:
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
                    Console.WriteLine("Joined date updated succesfully");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("\nEnter a valid choice");
                    this.UpdateStaff();
                    break;
            }
        }
    }
}
