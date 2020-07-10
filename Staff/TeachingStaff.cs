using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

//public enum SubjectEnum { malayalam, english, maths, social, science, hindi };


namespace Staff
{
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

        public override void AddStaff()
        {

            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed;
            int index = 1, choice;

            base.AddStaff();
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


            //XmlSerializer serializer = new XmlSerializer(this.GetType());
            //TextWriter writer = new StreamWriter(@"C:\Users\Win8.1 Pro 64bit\source\repos\Staff\Staff\Staff.xml");
            //serializer.Serialize(writer, this);
            //writer.Close();

        }

        public override void ViewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1},  Subject: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Subject, ContactNumber, DateOfJoin);
        }

        public override void UpdateStaff()
        {
            base.UpdateStaff();
        }
        public override void UpdateUniqueField()
        {
            string subject = System.Configuration.ConfigurationManager.AppSettings["subjects"];
            string[] subjects = subject.Split(',');
            bool succeed;
            int index, choice;
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
        }
        public override void EditMenu()
        {
            Console.WriteLine("\nSelect the field that you want to update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Subject");
            Console.WriteLine("3. Contact Number");
            Console.WriteLine("4. Joined Date");
            Console.WriteLine("5. Back to Home\n");
        }

    }
}
