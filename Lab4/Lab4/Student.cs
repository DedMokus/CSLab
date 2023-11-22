using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }

    

    internal class Student : Person, IDateAndCopy, IEnumerable, INotifyPropertyChanged
    {
        private Education _education;
        private int _group;
        private List<Exam> _exams = new();
        private List<Test> _tests = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public Student(Person student, Education education, int group):base(student.name,student.fam,student.date)
        {
            this._education = education;
            _group = group;
           
        }

        public Student(
            Person person,
            Education education,
            int group,
            List<Exam> exams,
            List<Test> test
        ) : base(person.name, person.fam, person.date)
        {
            _education = education;
            _group = group;
            _exams = exams;
            _tests = test;
        }

        public Student(string name, string fam, DateTime date, Education education, int group) : base(name, fam, date)
        {
            this._education = education;
            _group = group;
            
        }

        public Student():base()
        {
            _education = Education.Specialist;
            _group = 0;
        }

        public Person student
        {
            get { return new Person(base.Name, base.Fam, Date); }
            set
            {
                base.Name = value.name;
                base.Fam = value.fam;
                Date = value.date;
            }
        }

        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public new string Fam
        {
            get { return base.Fam; }
            set { base.Fam = value; }
        }

        public DateTime Date { get; set; }

        public Education Education
        {
            get { return _education; }
            set
            {
                if(_education != value )
                {
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Education)));
                    _education = value;
                }
            }
        }

        public int Group
        {
            get{return _group;}
            set
            { 
                if (value<100 | value > 599) { throw new Exception("Group must be greater than 100 and less than 600!"); }
                else
                {
                    if (_group != value)
                    {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Education)));
                        _group = value;
                    }
                    
                }
            }
        }

        public List<Exam> Exams
        {
            get { return _exams; }
            set { _exams = value; }
        }
        public List<Test> Tests
        {
            get { return _tests; }
            set { _tests = value; }
        }

        public double Average
        {
            get
            {
                double av = 0;
                int count = 0;
                foreach (Exam exam in _exams)
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
                if (ex == _education) { return true; }
                else { return false; }
            }
        }
        public void AddExams(List<Exam> param)
        {
            foreach (var item in param)
            {
                _exams.Add(item);
            }
        }

        public void AddExams(params Exam[] param)
        {
            this._exams.AddRange(param);
        }

        public void AddTests(List<Test> param)
        {
            foreach (var item in param)
            {
                _tests.Add(item);
            }
        }

        public override string ToString()
        {
            string str = string.Concat(this.student.ToString(), " ", this._education, " ", this._group,"\n");
            string exstr = string.Format("{0:15} {1:15} {2:15}\n", "Subject", "Mark", "Date");
            foreach (Exam item in this._exams)
            {
                exstr = $"{exstr}{string.Format("{0:15} {1:15} {2:15}\n", item.Subject, item.Mark, item.Date.ToString())}";
            }

            exstr = $"{exstr}{string.Format("{0:15} {1:15}\n\n", "Subject", "Is Done")}";

            foreach (Test item in this._tests)
            {
                exstr = $"{exstr}{string.Format("{0:15} {1:15}\n", item.Subject, item.IsDone)}";
            }
            return str+exstr;
        }


        public override string ToShortString()
        {
            string str = string.Concat(this.student.ToString(), " ", this._education, " ", this._group, " ", this.Average, "\n");
            return str;
        }

        public object DeepCopy()
        {
            Person newperson = (Person)student.DeepCopy();
            List<Exam> examsCopy = new();
            foreach (Exam exam in Exams)
            {
                examsCopy.Add((Exam)exam.DeepCopy());
            }
            Student copy = new Student(newperson, _education, _group);
            copy._exams = examsCopy;
            return copy;
        }

        public IEnumerator GetEnumerator()
        { 
            foreach(Exam item in this._exams)
            {
                yield return item;
            }
            foreach(Test item in this._tests)
            {
                yield return item;
            }
        }

        public IEnumerable GetEnumeratorParam(int grade)
        {
            foreach (Exam item in this._exams)
            {
                if (item.Mark>grade)
                {
                    yield return item;
                }
            }
        }

        public void sortExamsBySubjectName() => _exams.Sort();


        public void sortExamsByMark() => _exams.Sort();


        public void sortExamsByDate() => _exams.Sort(new ExamComparer());

        

        public static List<Exam> randExam(int size)
        {
            List<Exam> generated = new (size);
            for (int i = 0; i < size; ++i)
            {
                generated.Add(new(Guid.NewGuid().ToString(), Random.Shared.Next(1, 5), DateTime.Now));
            }
            return generated;
        }

        public static List<Test> randTest(int size)
        {
            List<Test> generated = new(size);
            for (int i = 0; i < size; ++i)
            {
                generated.Add(new(Guid.NewGuid().ToString(), Convert.ToBoolean(Random.Shared.Next(0, 1))));
            }
            return generated;
        }

        public static Student[] RandStudent(int size)
        {
            Student[] students = new Student[size];
            for (int i = 0; i < size; i++)
            {
                students[i] = new Student(
                    new Person(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now),
                    Enum.GetValues<Education>()[Random.Shared.Next(Enum.GetValues<Education>().Length)],
                    Random.Shared.Next(101, 599),
                    randExam(2),
                    randTest(2));
            }   
            return students;
        }
    }
}
