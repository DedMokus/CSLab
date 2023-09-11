﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Lab
{
    internal class Exam
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public System.DateTime Date { get; set; }

        Exam(string subject, int mark, DateTime date)
        {
            Subject = subject;
            Mark = mark;
            Date = date;
        }

        Exam()
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


    }
}
