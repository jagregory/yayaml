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

            Assert.That(result["hr"].ToString(), Is.EqualTo("65"));
        }

        [Test]
        public void SinglePairWithExtraWhitespaceBetweenKeyAndValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "hr:    65");

            Assert.That(result["hr"].ToString(), Is.EqualTo("65"));
        }

        [Test]
        public void SinglePairWithValueWrappedOntoNewLine()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "Fatal:",
                "  Unknown variable \"bar\"");

            Assert.That(result["Fatal"].ToString(), Is.EqualTo("Unknown variable \"bar\""));
        }

        [Test]
        public void SinglePairWithValueOnNewLineSpanningMultipleLines()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "Warning:",
                "  A slightly different error",
                "  message.");

            Assert.That(result["Warning"].ToString(), Is.EqualTo("A slightly different error message."));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "hr: 65",
                "avg: 0.278",
                "rbi: 147");

            Assert.That(result["hr"].ToString(), Is.EqualTo("65"));
            Assert.That(result["avg"].ToString(), Is.EqualTo("0.278"));
            Assert.That(result["rbi"].ToString(), Is.EqualTo("147"));
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

            Assert.That(result["one"].ToString(), Is.EqualTo("1"));
            Assert.That(result["two"].ToString(), Is.EqualTo("2"));
            Assert.That(result["three"].ToString(), Is.EqualTo("3"));
            Assert.That(result["four"].ToString(), Is.EqualTo("this is the fourth"));
            Assert.That(result["fifth"].ToString(), Is.EqualTo("5"));
        }
    }
}