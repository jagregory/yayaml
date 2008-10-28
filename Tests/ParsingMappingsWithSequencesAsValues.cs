using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingMappingsWithSequencesAsValues : AbstractParserTestFixture
    {
        [Test]
        public void SingleKeyWithSingleListItemAsValue()
        {
            var result = Parse<YamlMapping>(x => x.Mapping,
                "key:",
                "  - value");

            Assert.That(result.ContainsKey("key"), Is.True);

            var value = result["key"] as YamlSequence;

            Assert.That(value, Is.Not.Null);
            Assert.That(value.Count, Is.EqualTo(1));
            Assert.That(value[0].ToString(), Is.EqualTo("value"));
        }

        [Test]
        public void SingleKeyWithMultipleListItemsAsValue()
        {
            var result = Parse<YamlMapping>(x => x.Mapping,
                "key:",
                "  - value",
                "  - another value");

            Assert.That(result.ContainsKey("key"), Is.True);

            var value = result["key"] as YamlSequence;

            Assert.That(value, Is.Not.Null);
            Assert.That(value.Count, Is.EqualTo(2));
            Assert.That(value[0].ToString(), Is.EqualTo("value"));
            Assert.That(value[1].ToString(), Is.EqualTo("another value"));
        }

        [Test]
        public void MultipleKeysWithSingleListItemsAsValues()
        {
            var result = Parse<YamlMapping>(x => x.Mapping,
                "key:",
                "  - value",
                "key2:",
                "  - value2");

            Assert.That(result.ContainsKey("key"), Is.True);

            var first = result["key"] as YamlSequence;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.Count, Is.EqualTo(1));
            Assert.That(first[0].ToString(), Is.EqualTo("value"));

            Assert.That(result.ContainsKey("key2"), Is.True);

            var second = result["key2"] as YamlSequence;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.Count, Is.EqualTo(1));
            Assert.That(second[0].ToString(), Is.EqualTo("value2"));
        }

        [Test]
        public void MultipleKeysWithMultipleListItemsAsValues()
        {
            var result = Parse<YamlMapping>(x => x.Mapping,
                 "key:",
                 "  - value",
                 "  - value2",
                 "key2:",
                 "  - value3",
                 "  - value4");

            Assert.That(result.ContainsKey("key"), Is.True);

            var first = result["key"] as YamlSequence;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.Count, Is.EqualTo(2));
            Assert.That(first[0].ToString(), Is.EqualTo("value"));
            Assert.That(first[1].ToString(), Is.EqualTo("value2"));

            Assert.That(result.ContainsKey("key2"), Is.True);

            var second = result["key2"] as YamlSequence;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.Count, Is.EqualTo(2));
            Assert.That(second[0].ToString(), Is.EqualTo("value3"));
            Assert.That(second[1].ToString(), Is.EqualTo("value4"));
        }
    }
}