using System.IO;
using OMetaSharp;
using YaYAML.Parsing;

namespace YaYAML
{
    public class Yaml
    {
        public YamlDocument ParseText(string content)
        {
            return Grammars.ParseWith<YamlParser>(content, x => x.Document).As<YamlDocument>();
        }

        public YamlDocument ParseFile(string path)
        {
            var content = File.ReadAllText(path);

            return ParseText(content);
        }
    }
}