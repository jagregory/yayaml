namespace YaYAML
{
    public class YamlText : IYamlEntity
    {
        private readonly string content;

        public YamlText(string content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            return content;
        }
    }
}