using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class SpaceCountTests : AbstractParserTestFixture
    {
        [Test]
        public void SingleSpace()
        {
            var result = Parse<int>(x => x.SpaceCount, " ");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ManySpaces()
        {
            var result = Parse<int>(x => x.SpaceCount, "     ");

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void NoSpaces()
        {
            var result = Parse<int>(x => x.SpaceCount, "");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Word()
        {
            var result = Parse<int>(x => x.SpaceCount, "hello");

            Assert.That(result, Is.EqualTo(0));
        }
    }
}