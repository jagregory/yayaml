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

            Assert.That(result["key"][0].ToString(), Is.EqualTo("value"));
        }

        [Test]
        public void SingleKeyWithMultipleListItemsAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "key:",
                "  - value",
                "  - another value");

            Assert.That(result["key"][0].ToString(), Is.EqualTo("value"));
            Assert.That(result["key"][1].ToString(), Is.EqualTo("another value"));
        }

        [Test]
        public void MultipleKeysWithSingleListItemsAsValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "key:",
                "  - value",
                "key2:",
                "  - value2");

            Assert.That(result["key"][0].ToString(), Is.EqualTo("value"));
            Assert.That(result["key2"][0].ToString(), Is.EqualTo("value2"));
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

            Assert.That(result["key"][0].ToString(), Is.EqualTo("value"));
            Assert.That(result["key"][1].ToString(), Is.EqualTo("value2"));
            Assert.That(result["key2"][0].ToString(), Is.EqualTo("value3"));
            Assert.That(result["key2"][1].ToString(), Is.EqualTo("value4"));
        }
    }
}