namespace YaYAML
{
    public interface IYamlSequenceItem : IYamlEntity
    {
        IYamlEntity Contents { get; }
    }
}