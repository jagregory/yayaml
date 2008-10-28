namespace YaYAML
{
    public class YamlSequenceItem
    {
        public YamlSequenceItem(string contents)
        {
            Contents = contents;
        }

        public string Contents { get; private set; }
    }
}