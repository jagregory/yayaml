namespace YaYAML
{
    public class YamlMappingPair
    {
        public YamlMappingPair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}