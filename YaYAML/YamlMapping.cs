using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlMapping : IDictionary<string, string>, IYamlEntity
    {
        private readonly IDictionary<string, string> internalDictionary = new Dictionary<string, string>();

        public YamlMapping(IEnumerable<YamlMappingPair> pairs)
        {
            foreach (var pair in pairs)
            {
                Add(pair);
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return internalDictionary.GetEnumerator();
        }

        public void Add(KeyValuePair<string, string> item)
        {
            internalDictionary.Add(item);
        }

        public void Add(YamlMappingPair item)
        {
            internalDictionary.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            internalDictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return internalDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            internalDictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return internalDictionary.Remove(item);
        }

        public int Count
        {
            get { return internalDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return internalDictionary.IsReadOnly; }
        }

        public bool ContainsKey(string key)
        {
            return internalDictionary.ContainsKey(key);
        }

        public void Add(string key, string value)
        {
            internalDictionary.Add(key, value);
        }

        public bool Remove(string key)
        {
            return internalDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            return internalDictionary.TryGetValue(key, out value);
        }

        public string this[string key]
        {
            get { return internalDictionary[key]; }
            set { internalDictionary[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return internalDictionary.Keys; }
        }

        public ICollection<string> Values
        {
            get { return internalDictionary.Values; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}