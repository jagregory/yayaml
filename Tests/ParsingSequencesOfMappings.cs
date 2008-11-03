using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingSequencesOfMappings : AbstractParserTestFixture
    {
        [Test]
        public void SingleListItemWithOneKeyValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first");

            Assert.That(result[0]["name"].ToString(), Is.EqualTo("first"));
        }

        [Test]
        public void SingleListItemWithMultipleKeyValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first",
                "  value: test");

            Assert.That(result[0]["name"].ToString(), Is.EqualTo("first"));
            Assert.That(result[0]["value"].ToString(), Is.EqualTo("test"));
        }

        [Test]
        public void MultipleListItemsWithSingleKeyValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first",
                "- name: second");

            Assert.That(result[0]["name"].ToString(), Is.EqualTo("first"));
            Assert.That(result[1]["name"].ToString(), Is.EqualTo("second"));
        }

        [Test]
        public void MultipleListItemsWithMultipleKeyValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first",
                "  value: test",
                "- name: second",
                "  value: test2");

            Assert.That(result[0]["name"].ToString(), Is.EqualTo("first"));
            Assert.That(result[0]["value"].ToString(), Is.EqualTo("test"));
            Assert.That(result[1]["name"].ToString(), Is.EqualTo("second"));
            Assert.That(result[1]["value"].ToString(), Is.EqualTo("test2"));
        }

        [Test]
        public void SingleListItemWithHashWithListAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- value:",
                "    - one",
                "    - two");

            Assert.That(result[0]["value"][0].ToString(), Is.EqualTo("one"));
            Assert.That(result[0]["value"][1].ToString(), Is.EqualTo("two"));
        }
    }
}