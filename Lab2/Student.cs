using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Lab
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    internal class Student : Person
    {
        private Education education;
        private int Group;
        private System.Collections.ArrayList Exams;
        private System.Collections.ArrayList Tests;


        public Student(Person student, Education education, int group)
        {
            this.Name = student.name;
            this.Fam = student.fam;
            this.Date = student.date;
            this.education = education;
            Group = group;
            Exams = new System.Collections.ArrayList();
            Tests = new System.Collections.ArrayList();
        }

        public Student(string name, string fam, DateTime date, Education education, int group)
        {
            Name = name;
            Fam = fam;
            Date = date;
            this.education = education;
            Group = group;
            Exams = new System.Collections.ArrayList();
            Tests = new System.Collections.ArrayList();
        }

        public Student():base()
        {
            education = Education.Specialist;
            Group = 0;
            Exams = new System.Collections.ArrayList();
            Tests = new System.Collections.ArrayList();

        }

        public Person stud
        {
            get { return new Person(Name,Fam,Date); }
            set
            {
                Name = value.name;
                Fam = value.fam;
                Date = value.date;
            }
        }

        public new string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public new string fam
        {
            get { return Fam; }
            set { Fam = value; }
        }

        public new DateTime Date
        {
            get { return Date; }
            set { Date = value; }
        }

        public Education ed
        {
            get { return education; }
            set { education = value; }
        }

        public int group
        {
            get{return Group;}
            set
            { 
                if (value<100 | value > 599) { throw new Exception("Group must be greater than 100 and less than 600!"); }
                else { Group = value; }
            }
        }

        public System.Collections.ArrayList exams
        {
            get { return Exams; }
            set { Exams = value; }
        }
        public System.Collections.ArrayList tests
        {
            get { return Tests; }
            set { Tests = value; }
        }

        public double Average
        {
            get
            {
                double av = 0;
                int count = 0;
                foreach (Exam exam in Exams)
                {
                    av += exam.Mark;
                    count++;
                }
                av = av/ count;
                return av;
            }
        }

        public bool this[Education ex]
        {
            get
            {
                if (ex == education) { return true; }
                else { return false; }
            }
        }
        public void AddExams(System.Collections.ArrayList param)
        {
            foreach (var item in param)
            {
                Exams.Add(item);
            }
        }
        public void AddTests(System.Collections.ArrayList param)
        {
            foreach (var item in param)
            {
                Tests.Add(item);
            }
        }

        public override string ToString()
        {
            string str = string.Concat(this.stud.ToString(), " ", this.education, " ", this.Group,"\n");
            string exstr = string.Format("{:15} {:15} {:15}\n", "Subject", "Mark", "Date");
            foreach (Exam item in this.Exams)
            {
                exstr = $"{exstr}{string.Format("{:15} {:15} {:15}\n", item.Subject, item.Mark, item.Date.ToString())}";
            }

            exstr = $"{exstr}{string.Format("{:15} {:15}\n\n", "Subject", "Is Done")}";

            foreach (Test item in this.Tests)
            {
                exstr = $"{exstr}{string.Format("{:15} {:15}\n", item.Subject, item.IsDone)}";
            }
            return str+exstr;
        }


        public override string ToShortString()
        {
            string str = string.Concat(this.stud.ToString(), " ", this.education, " ", this.Group, " ", this.Average, "\n");
            return str;
        }

        public Student DeepCopy(Student p)
        {
            Person newperson = new Person(p.stud);
            Education newEducation = p.ed;
            int newgroup = p.group;
            return new Student(newperson, newEducation, newgroup);
        }
    }
}
