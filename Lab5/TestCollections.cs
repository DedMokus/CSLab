using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class TestCollections<TKey, TValue>
    {
        private List<TKey> list_keys = new();
        private List<string> strings = new();
        private Dictionary<TKey, TValue> dict = new();
        private Dictionary<string, TValue> dict_2 = new();
        private GenerateElement<TKey, TValue> generator;

        private (TKey, string)[] searchedElements;


        public TestCollections(int _elements_count, GenerateElement<TKey, TValue> _generator)
        {
            generator = _generator;

            for (int i = 0; i < _elements_count; i++)
            {
                KeyValuePair<TKey, TValue> pair = generator(i);
                list_keys.Add(pair.Key);
                dict.Add(pair.Key, pair.Value);
            }

            searchedElements = new (TKey, string)[]
            {
                (generator(0).Key, "first element"),
                (generator(_elements_count / 2).Key, "center element"),
                (generator(_elements_count - 1).Key, "last element"),
                (generator(_elements_count).Key, "non-existed element")
            };
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
