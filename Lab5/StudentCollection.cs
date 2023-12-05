using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{ 
    delegate void StudentsChangedHandler<TKey>(StudentCollection<TKey> source, StudentsChangedEventArgs<TKey> args)
        where TKey : notnull;

    internal class StudentCollection<TKey>
    {
        private readonly Dictionary<TKey, Student> _data = new();
        private KeySelector<TKey> _keySelector;

        public double MaxAverageMark
        {
            get
            {
                if (_data.Count == 0) return 0;

                double max = _data.Max((student) =>
                {
                    return student.Value.Exams.Average((exam) => exam.Mark);
                });
                return max;
            }
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation
        {
            get
            {
                return _data.GroupBy((student) => student.Value.Education);
            }
        }


        public StudentCollection(KeySelector<TKey> selector, string name) 
        {
            _keySelector = selector;
            Name = name;
        }

        public void AddDefault(int students_count)
        {
            for(int i = 0; i < students_count; i++)
            {
                Student student = new Student();
                Add(student);
            }
        }

        public void AddStudents(params Student[] _students)
        {
            foreach(Student student in _students)
            {
                Add(student);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education education)
        {
            return _data.Where((student) => student.Value.Education == education);
        }

        public override string ToString()
        {
            string result = "Students:\n";

            for (int i = 0; i < _data.Count; i++)
            {
                result += $"\nStudent {i + 1}:\n{_data.Values.ElementAt(i)}";
            }
            return result;
        }

        public string Name { get; set; }
        public event StudentsChangedHandler<TKey>? StudentsChanged;
        private Dictionary<TKey, PropertyChangedEventHandler> _propertyChangedHandlers = new();

        private void Add(Student student)
        {
            TKey key = _keySelector(student);
            _data.Add(key, student);
            StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Action.Add, nameof(_data), key));

            void PropertyChangedHandler(object? sender, PropertyChangedEventArgs args)
            {
                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Action.Property, args.PropertyName!, key));
            }

            _propertyChangedHandlers[key] = PropertyChangedHandler;
            student.PropertyChanged += PropertyChangedHandler;
        }

        private bool Remove(TKey key, Student value)
        {
            if (_data.Remove(key))
            {
                StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Action.Remove, nameof(_data), key));
                value.PropertyChanged -= _propertyChangedHandlers[key];
                _propertyChangedHandlers.Remove(key);
                return true;
            }
            return false;
        }
        public bool Remove(Student student)
        {
            foreach (var item in _data)
            {
                if (item.Value == student)
                {
                    return Remove(item.Key, item.Value);
                }
            }
            return false;
        }
    }
}
