using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

//public enum SubjectEnum { malayalam, english, maths, social, science, hindi };


namespace Staff
{
    [XmlRoot("TeachingStaff")]
    public class TeachingStaff : Staff
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

        public override void AddStaff(Enum type, List<Staff> list)
        {

            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed;
            int index = 1, choice;

            base.AddStaff(type, list);
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

        }

        public override void ViewStaff()
        {
            Console.WriteLine("{0}   Name: {1}, Type: {2},  Subject: {3},   Contact Number: {4},   Joining Date: {5}", EmpCode, Name, StaffType, Subject, ContactNumber, DateOfJoin);
        }

        public override void UpdateStaff()
        {
            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed;
            int index, choice;
            base.UpdateStaff();


            do
            {
                succeed = false;
                index = 1;
                try
                {
                    Console.WriteLine($"\nSelect language from choice ({this.Subject})");
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

        }

    }
}
