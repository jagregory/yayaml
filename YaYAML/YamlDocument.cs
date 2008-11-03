using System.Collections;
using System.Collections.Generic;

namespace YaYAML
{
    public class YamlDocument : IYamlEntity
    {
        private readonly IYamlEntity entity;

        public YamlDocument(IYamlEntity entity)
        {
            // this is a bit pants
            this.entity = entity;
        }

        public IEnumerator<IYamlEntity> GetEnumerator()
        {
            return entity.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IYamlEntity this[string key]
        {
            get { return entity[key]; }
        }

        public IYamlEntity this[int key]
        {
            get { return entity[key]; }
        }
    }
}