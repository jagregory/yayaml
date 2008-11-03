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
            var result = Parse<YamlDocument>(x => x.Document,
                "- Mark McGwire");

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(1));

            var content = seq[0] as YamlText;

            Assert.That(content, Is.Not.Null);
            Assert.That(content.ToString(), Is.EqualTo("Mark McGwire"));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- Mark McGwire",
                "- Sammy Sosa",
                "- Ken Griffey");

            var seq = result.Items[0] as YamlSequence;

            Assert.That(seq, Is.Not.Null);
            Assert.That(seq.Count, Is.EqualTo(3));

            var first = seq[0] as YamlText;

            Assert.That(first, Is.Not.Null);
            Assert.That(first.ToString(), Is.EqualTo("Mark McGwire"));

            var second = seq[1] as YamlText;

            Assert.That(second, Is.Not.Null);
            Assert.That(second.ToString(), Is.EqualTo("Sammy Sosa"));

            var third = seq[2] as YamlText;

            Assert.That(third, Is.Not.Null);
            Assert.That(third.ToString(), Is.EqualTo("Ken Griffey"));
        }
    }
}