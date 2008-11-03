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

            Assert.That(result[0].ToString(), Is.EqualTo("Mark McGwire"));
        }

        [Test]
        public void MultipleItems()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "- Mark McGwire",
                "- Sammy Sosa",
                "- Ken Griffey");

            Assert.That(result[0].ToString(), Is.EqualTo("Mark McGwire"));
            Assert.That(result[1].ToString(), Is.EqualTo("Sammy Sosa"));
            Assert.That(result[2].ToString(), Is.EqualTo("Ken Griffey"));
        }
    }
}