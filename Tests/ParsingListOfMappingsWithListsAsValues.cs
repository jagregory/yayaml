using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingListOfMappingsWithListsAsValues : AbstractParserTestFixture
    {
        [Test]
        public void MultipleListItemWithHashWithListAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- value:",
                "    - one",
                "    - two",
                "- three");

            Assert.That(result[0]["value"][0].ToString(), Is.EqualTo("one"));
            Assert.That(result[0]["value"][1].ToString(), Is.EqualTo("two"));
            Assert.That(result[1].ToString(), Is.EqualTo("three"));
        }

        [Test]
        public void MultipleListItemWithHashWithMultipleListAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- value:",
                "    - one",
                "    - two",
                "- value2:",
                "    - three",
                "    - four");

            Assert.That(result[0]["value"][0].ToString(), Is.EqualTo("one"));
            Assert.That(result[0]["value"][1].ToString(), Is.EqualTo("two"));
            Assert.That(result[1]["value2"][0].ToString(), Is.EqualTo("three"));
            Assert.That(result[1]["value2"][1].ToString(), Is.EqualTo("four"));
        }
    }
}