using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class TestCollections<TKey, TValue>
    {
        private List<TKey> list_keys = new();
        private List<string> strings = new();
        private Dictionary<TKey, TValue> dict = new();
        private Dictionary<string, TValue> dict_2 = new();
        private GenerateElement<TKey, TValue> generator;


        public TestCollections(int _elements_count, GenerateElement<TKey, TValue> _generator)
        {
            generator = _generator;

            for (int i = 0; i < _elements_count; i++)
            {
                KeyValuePair<TKey, TValue> pair = generator(i);
                list_keys.Add(pair.Key);
                dict.Add(pair.Key, pair.Value);
            }
        }



        public string FindInStringsList(string _value)
        {
            return strings.Find(str => str == _value) ?? "Not found";
        }



        public TKey? FindInKeysList(TKey _value)
        {
            return list_keys.Find(key => key.Equals(_value));
        }
    }
}
