// See https://aka.ms/new-console-template for more information

using Lab4;
using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        private static void UpdateEducation(Student student) =>
                student.Education = student.Education == Education.Bachelor ? Education.Specialist : Education.Bachelor;

        private static void UpdateGroup(Student student)
        {
            if (student.Group >= 599) student.Group = 101;
            else student.Group++;
        }

        public static void Main()
        {
            StudentCollection<string> firstCollection = new(it => it.Name + it.Fam, "First collection");
            StudentCollection<string> secondCollection = new(it => it.Name + it.Fam, "Second collection");

            Journal<string> journal = new();
            firstCollection.StudentsChanged += journal.On;
            secondCollection.StudentsChanged += journal.On;

            Student[] students = Student.RandStudent(4);

            for (int i = 0; i < students.Length; i++)
            {
                students[i].student = new Person(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),DateTime.Now);
            }
            firstCollection.AddStudents(students[..(students.Length / 2)]);
            secondCollection.AddStudents(students[(students.Length / 2)..]);

            foreach (Student student in students)
                UpdateEducation(student);
            foreach (Student student in students)
                UpdateGroup(student);

            firstCollection.Remove(students[0]);

            UpdateEducation(students[0]);
            UpdateGroup(students[0]);

            Console.WriteLine(journal.ToString());
        }

    }
}
