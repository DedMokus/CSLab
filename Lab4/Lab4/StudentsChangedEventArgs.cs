using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public Action Action { get; init; }
        public string ChangedProperty { get; init; }
        public TKey Key { get; init; }

        public StudentsChangedEventArgs(Action action, string changedProperty, TKey key)
        {
            Action = action;
            ChangedProperty = changedProperty;
            Key = key;
        }

        public override string ToString()
        {
            string str = $"{Action.ToString()}\n" +
                $"{ChangedProperty.ToString()}" +
                $"{Key.ToString()}";
            return str;
        }
    }
}
