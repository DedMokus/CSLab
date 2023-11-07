// See https://aka.ms/new-console-template for more information

using Lab3;

class Program
{
    private static void writeWithColor(string _message, ConsoleColor _color = ConsoleColor.Green)
    {
        Console.ForegroundColor = _color;
        Console.WriteLine(_message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void Main(string[] args)
    {
        Student student = new Student();
        student.AddExams(new Exam("Math", 4, new DateTime(2004, 2, 4)), new Exam("History", 3, new DateTime(2005, 2, 5)),
                         new Exam("Russian", 5, new DateTime(1999, 4, 4)), new Exam("Physic", 2, new DateTime(2010, 6, 4)),
                         new Exam("Subject", 1, new DateTime(2023, 2, 10)), new Exam("Subject2", 5, new DateTime(2014, 12, 14)));

        writeWithColor($"Student:\n\n");
        Console.WriteLine(student);
        student.sortExamsBySubjectName();
        writeWithColor($"Student after sorting by subject name:\n\n");
        Console.WriteLine(student);
        student.sortExamsByMark();
        writeWithColor($"Student after sorting by exams mark:\n\n");
        Console.WriteLine(student);
        student.sortExamsByDate();
        writeWithColor($"Student after sorting by date:\n\n");
        Console.WriteLine(student);

    }
}

