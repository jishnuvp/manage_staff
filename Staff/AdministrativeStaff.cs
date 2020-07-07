using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
{
    class AdministrativeStaff : Staff
    {
        private string role;
        //constructor

        public AdministrativeStaff()
        {

        }
        public AdministrativeStaff(string name, string role, string contact_number, DateTime date_of_join) : base(name, contact_number, date_of_join)
        {
            this.Name = name;
            this.Role = role;
            this.ContactNumber = contact_number;
            this.DateOfJoin = date_of_join;
        }

        //properties
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public void addStaff()
        {
            Console.WriteLine("Enter Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Role");
            role = Console.ReadLine();
            Console.WriteLine("Enter Contact Number");
            ContactNumber = Console.ReadLine();
            Console.WriteLine("Enter Date of Join (dd-mm-yyyy)");
            DateOfJoin = DateTime.Parse(Console.ReadLine());
        }
        public void viewStaff(int index, int slNum = 0)
        {
            Console.WriteLine("{0}   Name: {1},  Role: {2},   Contact Number: {3},   Joining Date: {4}", index, Name, Role, ContactNumber, DateOfJoin);

        }
        public void updateStaff()
        {
            int choice;
            Console.WriteLine("\nSelect the field that you want to update");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Role");
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
                    Console.WriteLine("Enter Name: ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Name updated succesfully");
                    break;
                case 2:
                    Console.WriteLine("Enter Role: ");
                    Role = Console.ReadLine();
                    Console.WriteLine("Subject updated succesfully");
                    break;
                case 3:
                    Console.WriteLine("Enter Contact Number: ");
                    ContactNumber = Console.ReadLine();
                    Console.WriteLine("Contact number updated succesfully");
                    break;
                case 4:
                    Console.WriteLine("Enter Joined Date: ");
                    DateOfJoin = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Joined date updated succesfully");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Enter a valid choice");
                    this.updateStaff(); break;
            }
        }
    }
}
