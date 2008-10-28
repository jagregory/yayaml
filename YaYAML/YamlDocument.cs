using System.Collections.Generic;

namespace YaYAML
{
    public class YamlDocument
    {
        public YamlDocument(IYamlEntity entity)
        {
            // this is a bit pants
            Items = new List<IYamlEntity>();
            Items.Add(entity);
        }

        public IList<IYamlEntity> Items { get; private set; }
    }
}