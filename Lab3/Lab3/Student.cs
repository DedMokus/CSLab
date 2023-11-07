using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    internal class Student : Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int Group;
        private List<Exam> Exams = new();
        private List<Test> Tests = new();


        public Student(Person student, Education education, int group):base(student.name,student.fam,student.date)
        {
            this.education = education;
            Group = group;
           
        }

        public Student(string name, string fam, DateTime date, Education education, int group) : base(name, fam, date)
        {
            this.education = education;
            Group = group;
            
        }

        public Student():base()
        {
            education = Education.Specialist;
            Group = 0;
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

        public DateTime Date { get; set; }

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

        public List<Exam> exams
        {
            get { return Exams; }
            set { Exams = value; }
        }
        public List<Test> tests
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
        public void AddExams(List<Exam> param)
        {
            foreach (var item in param)
            {
                Exams.Add(item);
            }
        }

        public void AddExams(params Exam[] param)
        {
            this.Exams.AddRange(param);
        }

        public void AddTests(List<Test> param)
        {
            foreach (var item in param)
            {
                Tests.Add(item);
            }
        }

        public override string ToString()
        {
            string str = string.Concat(this.stud.ToString(), " ", this.education, " ", this.Group,"\n");
            string exstr = string.Format("{0:15} {1:15} {2:15}\n", "Subject", "Mark", "Date");
            foreach (Exam item in this.Exams)
            {
                exstr = $"{exstr}{string.Format("{0:15} {1:15} {2:15}\n", item.Subject, item.Mark, item.Date.ToString())}";
            }

            exstr = $"{exstr}{string.Format("{0:15} {1:15}\n\n", "Subject", "Is Done")}";

            foreach (Test item in this.Tests)
            {
                exstr = $"{exstr}{string.Format("{0:15} {1:15}\n", item.Subject, item.IsDone)}";
            }
            return str+exstr;
        }


        public override string ToShortString()
        {
            string str = string.Concat(this.stud.ToString(), " ", this.education, " ", this.Group, " ", this.Average, "\n");
            return str;
        }

        public object DeepCopy()
        {
            Person newperson = (Person)stud.DeepCopy();
            List<Exam> examsCopy = new();
            foreach (Exam exam in exams)
            {
                examsCopy.Add((Exam)exam.DeepCopy());
            }
            Student copy = new Student(newperson, education, Group);
            copy.Exams = examsCopy;
            return copy;
        }

        public IEnumerator GetEnumerator()
        { 
            foreach(Exam item in this.Exams)
            {
                yield return item;
            }
            foreach(Test item in this.Tests)
            {
                yield return item;
            }
        }

        public IEnumerable GetEnumeratorParam(int grade)
        {
            foreach (Exam item in this.Exams)
            {
                if (item.Mark>grade)
                {
                    yield return item;
                }
            }
        }

        public void sortExamsBySubjectName() => Exams.Sort();


        public void sortExamsByMark() => Exams.Sort();


        public void sortExamsByDate() => Exams.Sort(new ExamComparer());
    }
}
