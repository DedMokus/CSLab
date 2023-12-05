﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [Serializable]
    internal class Test
    {
        public string Subject { get; set; }
        public bool IsDone {  get; set; }

        public Test() 
        {
            Subject = "Undefined";
            IsDone = false;
        }

        public Test(string subject,bool done)
        {
            Subject = subject;
            IsDone = done;
        }

        public override string ToString()
        {
            return string.Format("{:10}: {:5}",Subject,IsDone);
        }

    }
}
