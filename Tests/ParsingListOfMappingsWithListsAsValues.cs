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

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));

            var first = seq[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("value"), Is.True);

            var seq2 = first["value"] as YamlSequence;

            Assert.That(seq2, Is.Not.Null);
            Assert.That(seq2.Count, Is.EqualTo(2));
            Assert.That(seq2[0].ToString(), Is.EqualTo("one"));
            Assert.That(seq2[1].ToString(), Is.EqualTo("two"));
            Assert.That(seq[1].ToString(), Is.EqualTo("three"));
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

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));

            var first = seq[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("value"), Is.True);

            var firstSeq = first["value"] as YamlSequence;

            Assert.That(firstSeq, Is.Not.Null);
            Assert.That(firstSeq.Count, Is.EqualTo(2));
            Assert.That(firstSeq[0].ToString(), Is.EqualTo("one"));
            Assert.That(firstSeq[1].ToString(), Is.EqualTo("two"));

            var second = seq[1] as YamlMapping;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ContainsKey("value2"), Is.True);

            var secondSeq = second["value2"] as YamlSequence;

            Assert.That(secondSeq, Is.Not.Null);
            Assert.That(secondSeq.Count, Is.EqualTo(2));
            Assert.That(secondSeq[0].ToString(), Is.EqualTo("three"));
            Assert.That(secondSeq[1].ToString(), Is.EqualTo("four"));
        }
    }
}