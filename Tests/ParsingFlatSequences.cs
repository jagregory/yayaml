using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingFlatSequences : AbstractParserTestFixture
    {
        [Test]
        public void SingleItem()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- Mark McGwire");

            Assert.That(result.Count, Is.EqualTo(1));

            var content = result[0] as YamlText;

            Assert.That(content, Is.Not.Null);
            Assert.That(content.ToString(), Is.EqualTo("Mark McGwire"));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- Mark McGwire",
                "- Sammy Sosa",
                "- Ken Griffey");

            Assert.That(result.Count, Is.EqualTo(3));

            var first = result[0] as YamlText;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ToString(), Is.EqualTo("Mark McGwire"));

            var second = result[1] as YamlText;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ToString(), Is.EqualTo("Sammy Sosa"));

            var third = result[2] as YamlText;

            Assert.That(third, Is.Not.Null);
            Assert.That(third.ToString(), Is.EqualTo("Ken Griffey"));
        }
    }
}