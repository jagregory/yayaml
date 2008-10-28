using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlSequence : IList<IYamlSequenceItem>, IYamlEntity
    {
        private readonly IList<IYamlSequenceItem> internalList = new List<IYamlSequenceItem>();

        public YamlSequence(IEnumerable<IYamlSequenceItem> items)
        {
            foreach (var item in items)
            {
                internalList.Add(item);
            }
        }

        public IEnumerator<IYamlSequenceItem> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public void Add(IYamlSequenceItem item)
        {
            internalList.Add(item);
        }

        public void Clear()
        {
            internalList.Clear();
        }

        public bool Contains(IYamlSequenceItem item)
        {
            return internalList.Contains(item);
        }

        public void CopyTo(IYamlSequenceItem[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public bool Remove(IYamlSequenceItem item)
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

        public int IndexOf(IYamlSequenceItem item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, IYamlSequenceItem item)
        {
            internalList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            internalList.RemoveAt(index);
        }

        public IYamlSequenceItem this[int index]
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