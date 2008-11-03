using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingMappingsWithSequencesAsValues : AbstractParserTestFixture
    {
        [Test]
        public void SingleKeyWithSingleListItemAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "key:",
                "  - value");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("key"), Is.True);

            var value = map["key"] as YamlSequence;

            Assert.That(value, Is.Not.Null);
            Assert.That(value.Count, Is.EqualTo(1));
            Assert.That(value[0].ToString(), Is.EqualTo("value"));
        }

        [Test]
        public void SingleKeyWithMultipleListItemsAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "key:",
                "  - value",
                "  - another value");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("key"), Is.True);

            var value = map["key"] as YamlSequence;

            Assert.That(value, Is.Not.Null);
            Assert.That(value.Count, Is.EqualTo(2));
            Assert.That(value[0].ToString(), Is.EqualTo("value"));
            Assert.That(value[1].ToString(), Is.EqualTo("another value"));
        }

        [Test]
        public void MultipleKeysWithSingleListItemsAsValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "key:",
                "  - value",
                "key2:",
                "  - value2");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("key"), Is.True);

            var first = map["key"] as YamlSequence;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.Count, Is.EqualTo(1));
            Assert.That(first[0].ToString(), Is.EqualTo("value"));

            Assert.That(map.ContainsKey("key2"), Is.True);

            var second = map["key2"] as YamlSequence;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.Count, Is.EqualTo(1));
            Assert.That(second[0].ToString(), Is.EqualTo("value2"));
        }

        [Test]
        public void MultipleKeysWithMultipleListItemsAsValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                 "key:",
                 "  - value",
                 "  - value2",
                 "key2:",
                 "  - value3",
                 "  - value4");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("key"), Is.True);

            var first = map["key"] as YamlSequence;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.Count, Is.EqualTo(2));
            Assert.That(first[0].ToString(), Is.EqualTo("value"));
            Assert.That(first[1].ToString(), Is.EqualTo("value2"));

            Assert.That(map.ContainsKey("key2"), Is.True);

            var second = map["key2"] as YamlSequence;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.Count, Is.EqualTo(2));
            Assert.That(second[0].ToString(), Is.EqualTo("value3"));
            Assert.That(second[1].ToString(), Is.EqualTo("value4"));
        }
    }
}