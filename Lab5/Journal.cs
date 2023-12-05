using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Journal<Tkey> where Tkey : notnull
    {
        private List<JournalEntry> _entries = new();

        public void On(StudentCollection<Tkey> sender, StudentsChangedEventArgs<Tkey> args)
        {
            _entries.Add(new JournalEntry(sender.Name, args.Action, args.ChangedProperty, args.Key.ToString() ?? "null"));
        }

        public override string ToString()
        {
            string str = "";
            foreach(JournalEntry entry in _entries)
            {
                str = $"{str}{entry.ToString()}\n";
            }
            return str;
        }
    }
}
