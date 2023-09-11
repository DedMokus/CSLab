using System;
using System.Collections.Generic;
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

        Student(Person student, Education education, int group)
        {
            this.student = student;
            this.education = education;
            Group = group;
            Exams = new Exam[0];
        }

        Student()
        {
            student = C_Lab.Person();
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


    }
}
