// See https://aka.ms/new-console-template for more information

using C_Lab;

class Program
{
    static void Main(string[] args)
    {
        Student One = new();
        Console.WriteLine(One.ToShortString());
        Console.WriteLine("Specialist " + (int)Education.Specialist);
        Console.WriteLine("Bachelor " + (int)Education.Bachelor);
        Console.WriteLine("SecondEduation " + (int)Education.SecondEducation);

        One.stud = (new Person("Dima","Maletin",DateTime.Now));
        One.ed = Education.Specialist;
        One.group = 22;

        Exam[] ex = new Exam[0];
        ex[0] = new Exam("Math", 5, new DateTime(2023, 1, 12));
        One.exams = ex;

        Console.WriteLine(One.ToString());

        Exam[] exs = new Exam[5];
        exs[0] = new Exam("Math", 5, new DateTime(2023, 1, 12));
        exs[1] = new Exam("Physics", 4, new DateTime(2023, 1, 15));
        exs[2] = new Exam("PE", 5, new DateTime(2023, 1, 18));
        exs[3] = new Exam("Art", 3, new DateTime(2023, 1, 21));
        exs[4] = new Exam("Philosophy", 4, new DateTime(2023, 1, 27));

        One.AddExams(exs);
    }
}

