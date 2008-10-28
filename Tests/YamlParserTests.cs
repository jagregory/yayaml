using System;
using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class YamlParserTests
    {
        [Test]
        public void CanParseText()
        {
            var content = string.Join(Environment.NewLine, new[]
            {
                "- hello",
                "- there"
            });

            var yaml = new Yaml();
            var parsed = yaml.ParseText(content);

            Assert.That(parsed, Is.Not.Null);
            Assert.That(parsed.Items.Count, Is.EqualTo(1));
            Assert.That(parsed.Items[0], Is.TypeOf<YamlSequence>());

            var seq = (YamlSequence)parsed.Items[0];
            Assert.That(seq.Count, Is.EqualTo(2));
        }

        [Test]
        public void CanParseFile()
        {
            var yaml = new Yaml();
            var parsed = yaml.ParseFile(@"Resources\Sample.yaml");

            Assert.That(parsed, Is.Not.Null);
            Assert.That(parsed.Items.Count, Is.EqualTo(1));
            Assert.That(parsed.Items[0], Is.TypeOf<YamlSequence>());

            var seq = (YamlSequence)parsed.Items[0];
            Assert.That(seq.Count, Is.EqualTo(2));
        }
    }
}