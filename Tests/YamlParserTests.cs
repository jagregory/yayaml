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

        [Test]
        public void CanParseMoreComplexFile()
        {
            var yaml = new Yaml();
            var parsed = yaml.ParseFile(@"Resources\NestedSample.yaml");

            Assert.That(parsed, Is.Not.Null);

            // container
            Assert.That(parsed.Items.Count, Is.EqualTo(1));

            var seq = parsed.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));

            var first = seq[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("name"), Is.True);
            Assert.That(first.ContainsKey("age"), Is.True);
            Assert.That(first.ContainsKey("phones"), Is.True);

            ValidatePersonYaml(seq[0] as YamlMapping, "James", "23", new[]
            {
                "01234 432123",
                "01234 455674"
            });
            ValidatePersonYaml(seq[1] as YamlMapping, "Sara", "23", new[]
            {
                "03323 412314",
                "03432 885443"
            });
        }

        private void ValidatePersonYaml(YamlMapping map, string name, string age, string[] phones)
        {
            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("name"), Is.True);
            Assert.That(map.ContainsKey("age"), Is.True);
            Assert.That(map.ContainsKey("phones"), Is.True);

            Assert.That(map["name"].ToString(), Is.EqualTo(name));
            Assert.That(map["age"].ToString(), Is.EqualTo(age));

            var phoneSeq = map["phones"] as YamlSequence;

            Assert.That(phoneSeq, Is.Not.Null);
            Assert.That(phoneSeq.Count, Is.EqualTo(phones.Length));

            for (int i = 0; i < phones.Length; i++)
            {
                Assert.That(phoneSeq[i].ToString(), Is.EqualTo(phones[i]));
            }
        }
    }
}