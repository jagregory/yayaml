using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingListOfMappingsWithListsAsValues : AbstractParserTestFixture
    {
        [Test]
        public void MultipleListItemWithHashWithListAsValue()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- value:",
                "    - one",
                "    - two",
                "- three");

            Assert.That(result.Count, Is.EqualTo(2));

            var first = result[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("value"), Is.True);

            var seq = first["value"] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(2));
            Assert.That(seq[0].ToString(), Is.EqualTo("one"));
            Assert.That(seq[1].ToString(), Is.EqualTo("two"));
            Assert.That(result[1].ToString(), Is.EqualTo("three"));
        }

        [Test]
        public void MultipleListItemWithHashWithMultipleListAsValue()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- value:",
                "    - one",
                "    - two",
                "- value2:",
                "    - three",
                "    - four");

            Assert.That(result.Count, Is.EqualTo(2));

            var first = result[0] as YamlMapping;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ContainsKey("value"), Is.True);

            var firstSeq = first["value"] as YamlSequence;

            Assert.That(firstSeq, Is.Not.Null);
            Assert.That(firstSeq.Count, Is.EqualTo(2));
            Assert.That(firstSeq[0].ToString(), Is.EqualTo("one"));
            Assert.That(firstSeq[1].ToString(), Is.EqualTo("two"));

            var second = result[1] as YamlMapping;

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