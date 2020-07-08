﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public enum SubjectEnum { malayalam, english, maths, social, science, hindi };
namespace Staff
{
    class TeachingStaff : Staff
    {
        private SubjectEnum subject;
        
        //constructor

        public TeachingStaff()
        {

        }
        public TeachingStaff(string name, SubjectEnum subject, string contact_number, DateTime date_of_join) : base(name, contact_number, date_of_join)
        {
            this.Name = name;
            this.Subject = subject;
            this.ContactNumber = contact_number;
            this.DateOfJoin = date_of_join;
        }
        //properties
        public SubjectEnum Subject
        {
            get { return subject; }
            set {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new Exception("Subject is required");
                //}
                //if (!Regex.Match(value, "^[a-zA-Z]*$").Success)
                //{
                //    throw new Exception("Subject must contain characters only");
                //}
                subject = value; 
            }
        }

        public void addStaff()
        {

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
                    foreach (string str in Enum.GetNames(typeof(SubjectEnum)))
                    {
                        Console.WriteLine($"{index}. {str}");
                        index++;
                    }
                    if (!Int32.TryParse(Console.ReadLine(), out choice))
                    {
                        succeed = false;
                        Console.WriteLine("Enter a valid choice");
                    }
                    else
                    {
                        if(choice <= Enum.GetNames(typeof(SubjectEnum)).Length && choice > 0)
                        {
                            Subject = (SubjectEnum)(choice-1);
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

        public void viewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1},  Subject: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Subject, ContactNumber, DateOfJoin);
        }

        public void updateStaff()
        {
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
                        index = 1;
                        succeed = false;
                        try
                        {
                            Console.WriteLine("\nSelect your subject");
                            foreach (string str in Enum.GetNames(typeof(SubjectEnum)))
                            {
                                Console.WriteLine($"{index}. {str}");
                                index++;
                            }
                            if (!Int32.TryParse(Console.ReadLine(), out choice))
                            {
                                succeed = false;
                                Console.WriteLine("Enter a valid choice");
                            }
                            else
                            {
                                if (choice <= Enum.GetNames(typeof(SubjectEnum)).Length && choice > 0)
                                {
                                    Subject = (SubjectEnum)(choice - 1);
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
                    this.updateStaff();
                    break;
            }
        }
    }
}
