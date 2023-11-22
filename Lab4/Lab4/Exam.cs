using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
{
    internal class Exam:IDateAndCopy, System.IComparable, System.Collections.Generic.IComparer<Exam>
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public System.DateTime Date { get; set; }

        public Exam(string subject, int mark, DateTime date)
        {
            Subject = subject;
            Mark = mark;
            Date = date;
        }

        public Exam()
        {
            Subject = "Undefined";
            Mark = 0;
            Date = new System.DateTime();
        }

        public string ToString(Exam e)
        {
            string str = string.Concat(e.Subject, " ",e.Mark, " ",e.Date.ToString());
            return str;
        }

        public object DeepCopy()
        {
            Exam copy = new Exam(Subject, Mark, Date);
            return copy;
        }

        public int Compare(Exam x, Exam y)
        {
            return x.Mark.CompareTo(y.Mark);
        }

        public int CompareTo(object? obj)
        {
            Exam exam = obj as Exam ?? throw new ArgumentException("Obj is null!");
            if (exam != null)
                return Subject.CompareTo(exam.Subject);
            else
                throw new ArgumentException("Object is not exam");
        }
    }
}
