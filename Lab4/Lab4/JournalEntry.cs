using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class JournalEntry
    {
        public string CollectionName { get; }
        public Action Action { get; }
        public string ChangedProperty { get; }
        public string ChangedKey { get; }

        public JournalEntry(string CollectName, Action action, string changedProperty, string changedKey)
        {
            CollectionName = CollectName;
            Action = action;
            ChangedProperty = changedProperty;
            ChangedKey = changedKey;
        }

        public override string ToString()
        {
            string str = $"{CollectionName}\n" +
                $"{Action.ToString()}\n" +
                $"{ChangedProperty}\n" +
                $"{ChangedKey}\n";
            return str ;
        }
    }
}
