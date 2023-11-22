using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    delegate TKey KeySelector<TKey>(Student _student);
    
}
