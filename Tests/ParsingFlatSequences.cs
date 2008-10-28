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
            var result = Parse<YamlSequenceItem>(x => x.SequenceItem,
                "- Mark McGwire");

            Assert.That(result.Contents, Is.EqualTo("Mark McGwire"));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlSequence>(x => x.Sequence,
                "- Mark McGwire",
                "- Sammy Sosa",
                "- Ken Griffey");

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Contents, Is.EqualTo("Mark McGwire"));
            Assert.That(result[1].Contents, Is.EqualTo("Sammy Sosa"));
            Assert.That(result[2].Contents, Is.EqualTo("Ken Griffey"));
        }
    }
}
