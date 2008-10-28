namespace YaYAML
{
    public class YamlSequenceItem<T> : IYamlSequenceItem where T : IYamlEntity
    {
        public YamlSequenceItem(T contents)
        {
            Contents = contents;
        }

        public IYamlEntity Contents { get; private set; }
    }
}