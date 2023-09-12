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
    internal class Student
    {
        private Person student;
        private Education education;
        private int Group;
        private Exam[] Exams;

        public Student(Person student, Education education, int group)
        {
            this.student = student;
            this.education = education;
            Group = group;
            Exams = new Exam[0];
        }

        public Student()
        {
            student = new Person();
            education = Education.Specialist;
            Group = 0;
            Exams = new Exam[0];

        }

        public Person stud
        {
            get { return student; }
            set { student = value; }
        }

        public Education ed
        {
            get { return education; }
            set { education = value; }
        }

        public int group
        {
            get { return Group; }
            set { Group = value; }
        }

        public Exam[] exams
        {
            get { return Exams; }
            set { Exams = value; }
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
        public void AddExams(Exam[] param)
        {   
            int len = Exams.Length;
            Array.Resize(ref Exams, Exams.Length + param.Length);
            for (int i = len, j = 0;i<Exams.Length;i++,j++)
            {
                Exams[i] = param[j];
            }
        }

        public string ToString(Student stud)
        {
            string str = string.Concat(stud.student.ToString(), " ", stud.education, " ", stud.Group,"\n");
            string exstr = string.Format("{:15} {:15} {:15}\n", "Subject", "Mark", "Date");
            for (int i = 0; i < stud.Exams.Length; i++)
            {
                exstr = $"{exstr}{string.Format("{:15} {:15} {:15}\n", stud.Exams[i].Subject, stud.Exams[i].Mark, stud.Exams[i].Date.ToString())}";
            }
            return str+exstr;
        }

        public string ToString()
        {
            string str = string.Concat(this.student.ToString(), " ", this.education, " ", this.Group, "\n");
            string exstr = string.Format("{:15} {:15} {:15}\n", "Subject", "Mark", "Date");
            for (int i = 0; i < this.Exams.Length; i++)
            {
                exstr = $"{exstr}{string.Format("{:15} {:15} {:15}\n", this.Exams[i].Subject, this.Exams[i].Mark, this.Exams[i].Date.ToString())}";
            }
            return str + exstr;
        }

        public string ToShortString()
        {
            string str = string.Concat(this.student.ToString(), " ", this.education, " ", this.Group, " ", this.Average, "\n");
            return str;
        }
    }
}
