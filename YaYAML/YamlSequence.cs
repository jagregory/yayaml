using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlSequence : IList<IYamlEntity>, IYamlEntity
    {
        private readonly IList<IYamlEntity> internalList = new List<IYamlEntity>();

        public YamlSequence(IEnumerable<IYamlEntity> items)
        {
            foreach (var item in items)
            {
                internalList.Add(item);
            }
        }

        public IEnumerator<IYamlEntity> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public void Add(IYamlEntity item)
        {
            internalList.Add(item);
        }

        public void Clear()
        {
            internalList.Clear();
        }

        public bool Contains(IYamlEntity item)
        {
            return internalList.Contains(item);
        }

        public void CopyTo(IYamlEntity[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public bool Remove(IYamlEntity item)
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

        public int IndexOf(IYamlEntity item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, IYamlEntity item)
        {
            internalList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            internalList.RemoveAt(index);
        }

        public IYamlEntity this[int index]
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