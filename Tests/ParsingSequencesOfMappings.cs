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

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(1));

            var map = seq[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("name"), Is.True);
            Assert.That(map["name"].ToString(), Is.EqualTo("first"));
        }

        [Test]
        public void SingleListItemWithMultipleKeyValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first",
                "  value: test");

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(1));

            var map = seq[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("name"), Is.True);
            Assert.That(map.ContainsKey("value"), Is.True);
            Assert.That(map["name"].ToString(), Is.EqualTo("first"));
            Assert.That(map["value"].ToString(), Is.EqualTo("test"));
        }

        [Test]
        public void MultipleListItemsWithSingleKeyValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first",
                "- name: second");

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));

            var first = seq[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("name"), Is.True);
            Assert.That(first["name"].ToString(), Is.EqualTo("first"));

            var second = seq[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("name"), Is.True);
            Assert.That(second["name"].ToString(), Is.EqualTo("second"));
        }

        [Test]
        public void MultipleListItemsWithMultipleKeyValues()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- name: first",
                "  value: test",
                "- name: second",
                "  value: test2");

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));

            var first = seq[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("name"), Is.True);
            Assert.That(first.ContainsKey("value"), Is.True);
            Assert.That(first["name"].ToString(), Is.EqualTo("first"));
            Assert.That(first["value"].ToString(), Is.EqualTo("test"));

            var second = seq[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("name"), Is.True);
            Assert.That(second.ContainsKey("value"), Is.True);
            Assert.That(second["value"].ToString(), Is.EqualTo("test2"));
        }

        [Test]
        public void SingleListItemWithHashWithListAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- value:",
                "    - one",
                "    - two");

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(1));

            var first = seq[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("value"), Is.True);

            var seq2 = first["value"] as YamlSequence;

            Assert.That(seq2, Is.Not.Null);
            Assert.That(seq2.Count, Is.EqualTo(2));
        }
    }
}