using System;
using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlText : IYamlEntity
    {
        private readonly string content;

        public YamlText(string content)
        {
            this.content = content;
        }

        public IEnumerator<IYamlEntity> GetEnumerator()
        {
            yield return null;
        }

        public override string ToString()
        {
            return content;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IYamlEntity IIndexable<string, IYamlEntity>.this[string key]
        {
            get { return null; }
        }

        IYamlEntity IIndexable<int, IYamlEntity>.this[int key]
        {
            get { return null; }
        }
    }
}