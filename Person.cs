using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Lab
{
    internal class Person
    {
        
        string Name;
        string Fam;
        System.DateTime Date = new System.DateTime();

        public Person(string name, string fam, DateTime date)
        {
            Name = name;
            Fam = fam;
            Date = date;
        }

        public Person()
        {
            Name = "Undefined";
            Fam = "Undefined";
            Date = new System.DateTime();
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string fam
        {
            get { return Fam; }
            set { Fam = value; }
        }

        public DateTime date
        {
            get { return Date; }
            set { Date = value; }
        }

        public int[] dateint
        {
            get
            {
                int[] datereturn = { Date.Day, Date.Month, Date.Year };
                return datereturn;
            }
            set { Date = new System.DateTime(value[0], value[1], value[2]); }
        }

        public string ToString(Person p)
        {
            string str = string.Concat(p.Name, " ", p.Fam, " ", p.Date.ToString());
            return str;
        }

        public string ToShortString(Person p)
        {
            string str = string.Concat(p.Name, " ", p.Fam);
            return str;
        }



        
    }
}
