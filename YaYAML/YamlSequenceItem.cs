namespace YaYAML
{
    public class YamlSequenceItem : IYamlEntity
    {
        public YamlSequenceItem(string contents)
        {
            Contents = contents;
        }

        public string Contents { get; private set; }
    }
}