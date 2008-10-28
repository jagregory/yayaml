using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingSequencesOfMappings : AbstractParserTestFixture
    {
        [Test]
        public void SingleListItemWithOneKeyValue()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- name: first");

            Assert.That(result.Count, Is.EqualTo(1));

            var map = result[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("name"), Is.True);
            Assert.That(map["name"], Is.EqualTo("first"));
        }

        [Test]
        public void SingleListItemWithMultipleKeyValues()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- name: first",
                "  value: test");

            Assert.That(result.Count, Is.EqualTo(1));

            var map = result[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("name"), Is.True);
            Assert.That(map.ContainsKey("value"), Is.True);
            Assert.That(map["name"], Is.EqualTo("first"));
            Assert.That(map["value"], Is.EqualTo("test"));
        }

        [Test]
        public void MultipeListItemsWithSingleKeyValues()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- name: first",
                "- name: second");

            Assert.That(result.Count, Is.EqualTo(2));

            var first = result[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("name"), Is.True);
            Assert.That(first["name"], Is.EqualTo("first"));

            var second = result[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("name"), Is.True);
            Assert.That(second["name"], Is.EqualTo("second"));
        }

        [Test]
        public void MultipeListItemsWithMultipleKeyValues()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                                             "- name: first",
                                             "  value: test",
                                             "- name: second",
                                             "  value: test2");

            Assert.That(result.Count, Is.EqualTo(2));

            var first = result[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("name"), Is.True);
            Assert.That(first.ContainsKey("value"), Is.True);
            Assert.That(first["name"], Is.EqualTo("first"));
            Assert.That(first["value"], Is.EqualTo("test"));

            var second = result[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("name"), Is.True);
            Assert.That(second.ContainsKey("value"), Is.True);
            Assert.That(second["value"], Is.EqualTo("test2"));
        }
    }
}