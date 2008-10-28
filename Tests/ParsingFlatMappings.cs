using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingFlatMappings : AbstractParserTestFixture
    {
        [Test]
        public void SinglePair()
        {
            var result = Parse<YamlMappingPair>(x => x.MappingPair,
                "hr: 65");

            Assert.That(result.Key, Is.EqualTo("hr"));
            Assert.That(result.Value, Is.EqualTo("65"));
        }

        [Test]
        public void SinglePairWithExtraWhitespaceBetweenKeyAndValue()
        {
            var result = Parse<YamlMappingPair>(x => x.MappingPair,
                "hr:    65");

            Assert.That(result.Key, Is.EqualTo("hr"));
            Assert.That(result.Value, Is.EqualTo("65"));
        }

        [Test]
        public void SinglePairWithValueWrappedOntoNewLine()
        {
            var result = Parse<YamlMappingPair>(x => x.MappingPair,
                "Fatal:",
                "  Unknown variable \"bar\"");

            Assert.That(result.Key, Is.EqualTo("Fatal"));
            Assert.That(result.Value, Is.EqualTo("Unknown variable \"bar\""));
        }

        [Test]
        public void SinglePairWithValueOnNewLineSpanningMultipleLines()
        {
            var result = Parse<YamlMappingPair>(x => x.MappingPair,
                "Warning:",
                "  A slightly different error",
                "  message.");

            Assert.That(result.Key, Is.EqualTo("Warning"));
            Assert.That(result.Value, Is.EqualTo("A slightly different error message."));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlMapping>(x => x.Mapping,
                "hr: 65",
                "avg: 0.278",
                "rbi: 147");

            Assert.That(result.ContainsKey("hr"), Is.True);
            Assert.That(result.ContainsKey("avg"), Is.True);
            Assert.That(result.ContainsKey("rbi"), Is.True);
            Assert.That(result["hr"], Is.EqualTo("65"));
            Assert.That(result["avg"], Is.EqualTo("0.278"));
            Assert.That(result["rbi"], Is.EqualTo("147"));
        }

        [Test]
        public void MultipleItemsWithMultiline()
        {
            var result = Parse<YamlMapping>(x => x.Mapping,
                "one: 1",
                "two:",
                "  2",
                "three: 3",
                "four:",
                "  this is the",
                "  fourth",
                "fifth: 5");

            Assert.That(result.ContainsKey("one"), Is.True);
            Assert.That(result.ContainsKey("two"), Is.True);
            Assert.That(result.ContainsKey("three"), Is.True);
            Assert.That(result.ContainsKey("four"), Is.True);
            Assert.That(result.ContainsKey("fifth"), Is.True);
            Assert.That(result["one"], Is.EqualTo("1"));
            Assert.That(result["two"], Is.EqualTo("2"));
            Assert.That(result["three"], Is.EqualTo("3"));
            Assert.That(result["four"], Is.EqualTo("this is the fourth"));
            Assert.That(result["fifth"], Is.EqualTo("5"));
        }
    }
}