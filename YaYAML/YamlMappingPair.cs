namespace YaYAML
{
    public class YamlMappingPair
    {
        public YamlMappingPair(string key, IYamlEntity value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public IYamlEntity Value { get; private set; }
    }
}