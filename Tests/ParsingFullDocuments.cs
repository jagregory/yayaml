using System.Collections.Generic;
using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingFullDocuments : AbstractParserTestFixture
    {
        [Test]
        public void CanParseList()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- Mark McGwire",
                "- Sammy Sosa",
                "- Ken Griffey");

            Assert.That(result.Items.Count, Is.EqualTo(1));
            Assert.That(result.Items[0], Is.TypeOf<YamlSequence>());
        }

        [Test]
        public void CanParseMapping()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "hr: 65",
                "avg: 0.278",
                "rbi: 147");

            Assert.That(result.Items.Count, Is.EqualTo(1));
            Assert.That(result.Items[0], Is.TypeOf<YamlMapping>());
        }
    }
}