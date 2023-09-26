using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Lab
{
    internal class Exam:IDateAndCopy
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

        public Exam DeepCopy(Exam p)
        {
            string newSubject = p.Subject;
            int newMark = p.Mark;
            System.DateTime newDate = p.Date;
            return new Exam(newSubject, newMark, newDate);
        }

    }
}
