// See https://aka.ms/new-console-template for more information

using C_Lab;

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person("Misha", "Radaev", new DateTime(2023, 9, 13));
        Person person2 = new Person("Misha", "Radaev", new DateTime(2023, 9, 13));

        Console.WriteLine(person1 == person2);
        Console.WriteLine("Хэш-код для объекта 1: {0}", person1.GetHashCode());
        Console.WriteLine("Хэш-код для объекта 2: {0}\n", person2.GetHashCode());

        Student student1 = new Student(person1, Education.Bachelor, 24);
        student1.AddExams(new Exam("Math", 5, new DateTime(2023, 9, 14)), new Exam("Physics", 4, new DateTime(2023, 6, 27)), new Exam("Chemistry", 3, new DateTime(2023, 6, 28)));
        Console.WriteLine(student1.ToString());
        Console.WriteLine("\n");

        Console.WriteLine(student1.stud.ToString());

        IDateAndCopy stud2 = new Student(person1,Education.Bachelor, 24);
        Student copyst2 = (Student)stud2.DeepCopy();

        copyst2.name = "Dima";
        Console.WriteLine(copyst2.name);
        Console.WriteLine("Copy of Student: " + copyst2.ToString());
        Console.WriteLine("Original Student: " + stud2.ToString());
        Console.WriteLine(stud2.GetHashCode());
        Console.WriteLine(copyst2.GetHashCode());


        try
        {
            student1.group = 99;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

        }

        foreach (var Ex in student1)
        {
            Console.WriteLine(Ex.ToString());
        }
        foreach (var Ex in student1.GetEnumeratorParam(4))
        {
            Console.WriteLine(Ex.ToString());
        }
    }
}

