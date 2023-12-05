// See https://aka.ms/new-console-template for more information
#pragma warning disable SYSLIB0011
using Lab5;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Reflection;

namespace Lab5
{
    class Program
    {
        private static Random random = new Random();

        public static void MoveData<T1, T2>(T1 source, ref T2 destination)
        {
            FieldInfo[] sourceFields = source!.GetType().GetFields();
            FieldInfo[] destinationFields = destination!.GetType().GetFields();

            foreach (FieldInfo sourceField in sourceFields)
            {
                FieldInfo? destField = destinationFields.FirstOrDefault(it => it.Name == sourceField.Name);
                if (destField == null) continue;
                try
                {
                    destField.SetValue(destination, sourceField.GetValue(source));
                }
                catch
                {
                    continue;
                }
            }

            PropertyInfo[] sourceProps = source!.GetType().GetProperties();
            PropertyInfo[] destinationProps = destination!.GetType().GetProperties();

            foreach (PropertyInfo sourceProp in sourceProps)
            {
                PropertyInfo? destProp = destinationProps.FirstOrDefault(it => it.Name == sourceProp.Name);
                if (destProp == null) continue;
                try
                {
                    destProp.SetValue(destination, sourceProp.GetValue(source));
                }
                catch
                {
                    continue;
                }
            }
        }

        private static string RandomString(int _length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, _length).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private static DateTime RandomDate()
        {
            return new DateTime(random.Next(2023), random.Next(1, 12), random.Next(1, 28));
        }


        private static Education RandomEducation()
        {
            Education[] education_types = { Education.Specialist, Education.Bachelor, Education.SecondEducation };
            return education_types[random.Next(0, 3)];
        }



        private static Exam[] RandomExams(int _count)
        {
            List<Exam> exams = new List<Exam>();
            for (int i = 0; i < _count; i++)
            {
                Exam exam = new Exam(RandomString(random.Next(5, 10)), random.Next(1, 5), RandomDate());
                exams.Add(exam);
            }
            return exams.ToArray();
        }



        private static Person RandomPerson()
        {
            return new Person(RandomString(10), RandomString(7), RandomDate());
        }



        private static Student RandomStudent()
        {
            return new Student(RandomPerson(), RandomEducation(), random.Next(100));
        }



        private static Student[] RandomStudents(int _count)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < _count; i++)
            {
                Student student = RandomStudent();
                students.Add(student);
                student.AddExams(RandomExams(random.Next(3, 5)));
            }
            return students.ToArray();
        }

        private static bool Save<T>(string fileName, T obj)
        {
            IFormatter formatter = new BinaryFormatter();

            FileStream? fileStream = null;
            try
            {
                fileStream = File.OpenWrite(fileName);
                formatter.Serialize(fileStream, obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                fileStream?.Dispose();
            }
        }
        private static bool Load<T>(string fileName, ref T obj)
        {
            IFormatter formatter = new BinaryFormatter();

            FileStream? fileStream = null;
            try
            {
                fileStream = File.OpenRead(fileName);
                T deserialized = (T)formatter.Deserialize(fileStream);

                MoveData(deserialized, ref obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        public static void Main()
        {
            Student student = RandomStudent();
            Console.WriteLine(student.ToString());
            Console.WriteLine("Student");
            Student copy = student.DeepCopy();
            Console.WriteLine("DeepCopy");
            Console.WriteLine(copy.ToString());

            string fileName;
            Student loadedStudent = new();
            while (true)
            {
                Console.Write("Enter file name: ");
                try
                {
                    fileName = Console.ReadLine()!;
                    if (!File.Exists(fileName))
                    {
                        Console.WriteLine("New file created!");
                        File.Create(fileName).Dispose();
                    }
                    else
                    {
                        Console.WriteLine(loadedStudent.Load(fileName)
                            ? "Successfully loaded"
                            : "Error while loading student from file!");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter correct file name");
                }
            }

            Console.WriteLine("Current student");
            Console.WriteLine(loadedStudent.ToString());


            loadedStudent.AddFromConsole();
            Console.WriteLine(loadedStudent.Save(fileName)
                ? "Student successfully saved to file"
                : "Error while saving student");
            Console.WriteLine("Current student");
            Console.WriteLine(loadedStudent.ToString());


            Console.WriteLine(Load(fileName, ref loadedStudent)
                ? "Successfully loaded"
                : "Error while loading student from file!");
            loadedStudent.AddFromConsole();
            Console.WriteLine(Save(fileName, loadedStudent)
                ? "Student successfully saved to file"
                : "Error while saving student");

            Console.WriteLine("Current student");
            Console.WriteLine(loadedStudent.ToString());
        }

    }
}
