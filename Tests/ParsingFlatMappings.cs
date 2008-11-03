using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingFlatMappings : AbstractParserTestFixture
    {
        [Test]
        public void SinglePair()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "hr: 65");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("hr"), Is.True);
            Assert.That(map["hr"].ToString(), Is.EqualTo("65"));
        }

        [Test]
        public void SinglePairWithExtraWhitespaceBetweenKeyAndValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "hr:    65");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("hr"), Is.True);
            Assert.That(map["hr"].ToString(), Is.EqualTo("65"));
        }

        [Test]
        public void SinglePairWithValueWrappedOntoNewLine()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "Fatal:",
                "  Unknown variable \"bar\"");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("Fatal"), Is.True);
            Assert.That(map["Fatal"].ToString(), Is.EqualTo("Unknown variable \"bar\""));
        }

        [Test]
        public void SinglePairWithValueOnNewLineSpanningMultipleLines()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "Warning:",
                "  A slightly different error",
                "  message.");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("Warning"), Is.True);
            Assert.That(map["Warning"].ToString(), Is.EqualTo("A slightly different error message."));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "hr: 65",
                "avg: 0.278",
                "rbi: 147");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("hr"), Is.True);
            Assert.That(map.ContainsKey("avg"), Is.True);
            Assert.That(map.ContainsKey("rbi"), Is.True);
            Assert.That(map["hr"].ToString(), Is.EqualTo("65"));
            Assert.That(map["avg"].ToString(), Is.EqualTo("0.278"));
            Assert.That(map["rbi"].ToString(), Is.EqualTo("147"));
        }

        [Test]
        public void MultipleItemsWithMultiline()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "one: 1",
                "two:",
                "  2",
                "three: 3",
                "four:",
                "  this is the",
                "  fourth",
                "fifth: 5");

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("one"), Is.True);
            Assert.That(map.ContainsKey("two"), Is.True);
            Assert.That(map.ContainsKey("three"), Is.True);
            Assert.That(map.ContainsKey("four"), Is.True);
            Assert.That(map.ContainsKey("fifth"), Is.True);
            Assert.That(map["one"].ToString(), Is.EqualTo("1"));
            Assert.That(map["two"].ToString(), Is.EqualTo("2"));
            Assert.That(map["three"].ToString(), Is.EqualTo("3"));
            Assert.That(map["four"].ToString(), Is.EqualTo("this is the fourth"));
            Assert.That(map["fifth"].ToString(), Is.EqualTo("5"));
        }
    }
}