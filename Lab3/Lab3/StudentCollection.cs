using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class StudentCollection<TKey>
    {
        private readonly Dictionary<TKey, Student> students = new();
        private KeySelector<TKey> keySelector;

        public double MaxAverageMark
        {
            get
            {
                if (students.Count == 0) return 0;

                double max = students.Max((student) =>
                {
                    return student.Value.exams.Average((exam) => exam.Mark);
                });
                return max;
            }
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation
        {
            get
            {
                return students.GroupBy((student) => student.Value.ed);
            }
        }


        public StudentCollection(KeySelector<TKey> selector) 
        {
            keySelector = selector;
        }

        public void AddDefault(int students_count)
        {
            for(int i = 0; i < students_count; i++)
            {
                Student student = new Student();
                students.Add(_keySelector(student), student);
            }
        }

        public void AddStudents(params Student[] _students)
        {
            foreach(Student student in _students)
            {
                students.Add(_keySelector(student), student);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education education)
        {
            return students.Where((student) => student.Value.ed == education);
        }

        public override string ToString()
        {
            string result = "Students:\n";

            for (int i = 0; i < students.Count; i++)
            {
                result += $"\nStudent {i + 1}:\n{students.Values.ElementAt(i)}";
            }
            return result;
        }
    }
}
