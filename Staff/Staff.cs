using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
{
    abstract class Staff
    {
        private string name;
        private string contact_number;
        protected string date_of_join;

        //private DateTime date_of_join;

        //constructor
        public Staff()
        {

        }

        public Staff(string name, string contact_number, string date_of_join)
        {
            this.name = name;
            this.contact_number = contact_number;
            this.date_of_join = date_of_join;
        }
        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ContactNumber
        {
            get { return contact_number; }
            set { contact_number = value; }
        }
        public string DateOfJoin
        {
            get { return date_of_join; }
            set { date_of_join = value; }
        }
    }
}
