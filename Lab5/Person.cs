using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [Serializable]
    internal class Person
    {
        
        protected string Name;
        protected string Fam;
        protected System.DateTime Date = new System.DateTime();

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

        public Person(Person other)
        {
            Name = other.Name;
            Fam = other.Fam;
            Date = other.Date;
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


        public override string ToString()
        {
            string str = string.Concat(this.Name, " ", this.Fam, " ", this.Date.ToString());
            return str;
        }


        public virtual string ToShortString()
        {
            string str = string.Concat(this.Name, " ", this.Fam);
            return str;
        }

        public override bool Equals(Object? other)
        {
            Person p = other as Person;
            return (this.Name == p.Name) & (this.Fam == p.Fam) & (this.Date == p.Date);
        }

        public static bool operator ==(Person a, Person b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Person a, Person b)
        {
            return !(a.Equals(b));
        }

        public override int GetHashCode()
        {
            int Hash = 0;
            Hash += this.Name.GetHashCode();
            Hash += this.Fam.GetHashCode();
            Hash += this.Date.GetHashCode();
            return Hash;
        }

        public object DeepCopy()
        {
            return new Person(Name, Fam, Date);
        }



    }
}
