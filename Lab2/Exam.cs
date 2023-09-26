using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public object DeepCopy()
        {
            Exam copy = new Exam(Subject, Mark, Date);
            return copy;
        }

    }
}
