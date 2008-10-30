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
            Assert.That(map["name"].ToString(), Is.EqualTo("first"));
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
            Assert.That(map["name"].ToString(), Is.EqualTo("first"));
            Assert.That(map["value"].ToString(), Is.EqualTo("test"));
        }

        [Test]
        public void MultipleListItemsWithSingleKeyValues()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- name: first",
                "- name: second");

            Assert.That(result.Count, Is.EqualTo(2));

            var first = result[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("name"), Is.True);
            Assert.That(first["name"].ToString(), Is.EqualTo("first"));

            var second = result[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("name"), Is.True);
            Assert.That(second["name"].ToString(), Is.EqualTo("second"));
        }

        [Test]
        public void MultipleListItemsWithMultipleKeyValues()
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
            Assert.That(first["name"].ToString(), Is.EqualTo("first"));
            Assert.That(first["value"].ToString(), Is.EqualTo("test"));

            var second = result[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("name"), Is.True);
            Assert.That(second.ContainsKey("value"), Is.True);
            Assert.That(second["value"].ToString(), Is.EqualTo("test2"));
        }

        [Test]
        public void SingleListItemWithHashWithListAsValue()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- value:",
                "    - one",
                "    - two");

            Assert.That(result.Count, Is.EqualTo(1));

            var first = result[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("value"), Is.True);

            var seq = first["value"] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));
        }
    }
}