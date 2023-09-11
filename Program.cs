// See https://aka.ms/new-console-template for more information

public class Person
{
    string Name;
    string Fam;
    System.DateTime Date = new System.DateTime();

    Person(string name, string fam, DateTime date)
    {
        Name = name;
        Fam = fam;
        Date = date;
    }

    Person()
    {
        Name = "Undefined";
        Fam = "Undefined";
        Date = new System.DateTime();
    }

    public string name
    {
        get { return Name; }
        set { Name = value; }
    }

    public string fam
    {
        get { return Fam; }
        set { Fam = value; }
    }

    public DateTime date
    {
        get { return Date; }
        set { Date = value; }
    }

    public int[] dateint
    {
        get
        {
            int[] datereturn = { Date.Day, Date.Month, Date.Year };
            return datereturn;
        }
        set { Date = new System.DateTime(value[0], value[1], value[2]); }
    }

    public string ToString(Person p)
    {
        string str = string.Concat(p.Name, " ",p.Fam, " ",p.Date);
        return str;
    }

    public string ToShortString(Person p) 
    {
        string str = string.Concat(p.Name, " ", p.Fam);
        return str;
    }



}


