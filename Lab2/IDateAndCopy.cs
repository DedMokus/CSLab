using C_Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IDateAndCopy
{
    object DeepCopy();
   

    System.DateTime Date { get; set; }
}
