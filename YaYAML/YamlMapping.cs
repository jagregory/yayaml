using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlMapping : IDictionary<string, IYamlEntity>, IYamlEntity
    {
        private readonly IDictionary<string, IYamlEntity> internalDictionary = new Dictionary<string, IYamlEntity>();

        public YamlMapping(YamlMappingPair head, IEnumerable<YamlMappingPair> pairs)
        {
            Add(head);

            foreach (var pair in pairs)
            {
                Add(pair);
            }
        }

        public YamlMapping(IEnumerable<YamlMappingPair> pairs)
        {
            foreach (var pair in pairs)
            {
                Add(pair);
            }
        }

        public IEnumerator<KeyValuePair<string, IYamlEntity>> GetEnumerator()
        {
            return internalDictionary.GetEnumerator();
        }

        public void Add(KeyValuePair<string, IYamlEntity> item)
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

        public bool Contains(KeyValuePair<string, IYamlEntity> item)
        {
            return internalDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, IYamlEntity>[] array, int arrayIndex)
        {
            internalDictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, IYamlEntity> item)
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

        public void Add(string key, IYamlEntity value)
        {
            internalDictionary.Add(key, value);
        }

        public bool Remove(string key)
        {
            return internalDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out IYamlEntity value)
        {
            return internalDictionary.TryGetValue(key, out value);
        }

        public IYamlEntity this[string key]
        {
            get { return internalDictionary[key]; }
            set { internalDictionary[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return internalDictionary.Keys; }
        }

        public ICollection<IYamlEntity> Values
        {
            get { return internalDictionary.Values; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}