using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlSequence : IList<YamlSequenceItem>, IYamlEntity
    {
        private readonly IList<YamlSequenceItem> internalList = new List<YamlSequenceItem>();

        public YamlSequence(IEnumerable<YamlSequenceItem> items)
        {
            foreach (var item in items)
            {
                internalList.Add(item);
            }
        }

        public IEnumerator<YamlSequenceItem> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public void Add(YamlSequenceItem item)
        {
            internalList.Add(item);
        }

        public void Clear()
        {
            internalList.Clear();
        }

        public bool Contains(YamlSequenceItem item)
        {
            return internalList.Contains(item);
        }

        public void CopyTo(YamlSequenceItem[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public bool Remove(YamlSequenceItem item)
        {
            return internalList.Remove(item);
        }

        public int Count
        {
            get { return internalList.Count; }
        }

        public bool IsReadOnly
        {
            get { return internalList.IsReadOnly; }
        }

        public int IndexOf(YamlSequenceItem item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, YamlSequenceItem item)
        {
            internalList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            internalList.RemoveAt(index);
        }

        public YamlSequenceItem this[int index]
        {
            get { return internalList[index]; }
            set { internalList[index] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}