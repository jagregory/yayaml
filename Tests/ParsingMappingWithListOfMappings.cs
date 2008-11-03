using NUnit.Framework;

namespace YaYAML.Tests
{
    [TestFixture]
    public class ParsingMappingWithListOfMappings : AbstractParserTestFixture
    {
        [Test]
        public void MultipleListItemWithHashWithListAsValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "good_people:",
                "  - name: James",
                "    reason: always happy",
                "  - name: Sara",
                "    reason: is nice",
                "bad_people:",
                "  - name: Bob",
                "    reason: smells",
                "  - name: Uma",
                "    reason: too tall");

            VerifyPerson(result["good_people"][0] as YamlMapping, "James", "always happy");
            VerifyPerson(result["good_people"][1] as YamlMapping, "Sara", "is nice");
            VerifyPerson(result["bad_people"][0] as YamlMapping, "Bob", "smells");
            VerifyPerson(result["bad_people"][1] as YamlMapping, "Uma", "too tall");
        }

        [Test]
        public void ListOfHashesWithListOfHashWithMultilineValue()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "good_people:",
                "  - name: James",
                "    extras:",
                "      - mirror2:",
                "          one",
                "  - name: Sara");

            var map = result[0] as YamlMapping;

            Assert.That(result["good_people"][0]["extras"][0]["mirror2"].ToString(), Is.EqualTo("one"));
        }

        [Test]
        public void ListOfHashesWithListOfHashWithMultilineValue2()
        {
            var result = Parse<YamlDocument>(x => x.Document,
                "good_people:",
                "  - name: James",
                "    extras:",
                "      - mirror2:",
                "          - one",
                "          - two",
                "  - name: Sara");

            Assert.That(result["good_people"][0]["extras"][0]["mirror2"][0].ToString(), Is.EqualTo("one"));
            Assert.That(result["good_people"][0]["extras"][0]["mirror2"][1].ToString(), Is.EqualTo("two"));
        }

        private void VerifyPerson(YamlMapping mapping, string name, string reason)
        {
            Assert.That(mapping, Is.Not.Null);
            Assert.That(mapping.ContainsKey("name"), Is.True);
            Assert.That(mapping["name"].ToString(), Is.EqualTo(name));
            Assert.That(mapping.ContainsKey("reason"), Is.True);
            Assert.That(mapping["reason"].ToString(), Is.EqualTo(reason));
        }
    }
}