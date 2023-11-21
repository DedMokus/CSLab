using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void RunAllTests()
        {
            foreach ((TKey searchElement, string searchElementLabel) in searchedElements)
            {
                Console.WriteLine($"Tests for: {searchElementLabel}");

                StringBuilder elementSearchesResultBuilder = new StringBuilder();
                (TimeSpan, string)[] runResults = RunTestsFor(searchElement);
                for (int i = 0; i < runResults.Length; i++)
                {
                    TimeSpan runResult = runResults[i].Item1;
                    string runLabel = runResults[i].Item2;

                    elementSearchesResultBuilder.Append($"Time for {runLabel}: {runResult}\n");
                }

                Console.WriteLine(elementSearchesResultBuilder.ToString());
            }
        }

        private (TimeSpan, string)[] RunTestsFor(TKey key) => new[]
        {
            (Run(() =>
            {
                list_keys.Contains(key);
            }), "item in list with keys"),
            (Run(() =>
            {
                strings.Contains(key.ToString()!);
            }), "item in list with strings"),
            (Run(() =>
            {
                dict.ContainsKey(key);
            }), "key in dict with keys"),
            (Run(() =>
            {
                dict_2.ContainsKey(key.ToString()!);
            }), "key in with string"),
            (Run(() =>
            {
                try
                {
                    dict.ContainsValue(dict[key]);
                }
                catch
                {
                    // ignored
                }
            }), "value in dict with keys"),
        };

        private readonly Stopwatch _stopwatch = new();

        public TimeSpan Run(Action action, int tries = 20)
        {
            long totalTicks = 0;
            for (int i = 0; i < tries; i++)
            {
                totalTicks += SimpleRun(action).Ticks;
            }
            return new TimeSpan(totalTicks / tries);
        }

        private TimeSpan SimpleRun(Action action)
        {
            _stopwatch.Restart();
            action();
            _stopwatch.Stop();
            return _stopwatch.Elapsed;
        }

    }
}
