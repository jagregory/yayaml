using System.Collections.Generic;

namespace YaYAML
{
    public interface IYamlEntity
        : IEnumerable<IYamlEntity>, IIndexable<string, IYamlEntity>, IIndexable<int, IYamlEntity>
    {}
}