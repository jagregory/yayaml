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

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("good_people"), Is.True,
                "Expected key 'good_people'");

            var good_people = map["good_people"] as YamlSequence;

            Assert.That(good_people, Is.Not.Null);
            Assert.That(good_people.Count, Is.EqualTo(2));

            VerifyPerson(good_people[0] as YamlMapping, "James", "always happy");
            VerifyPerson(good_people[1] as YamlMapping, "Sara", "is nice");

            Assert.That(map.ContainsKey("bad_people"), Is.True,
                "Expected key 'bad_people'");

            var bad_people = map["bad_people"] as YamlSequence;

            Assert.That(bad_people, Is.Not.Null);
            Assert.That(bad_people.Count, Is.EqualTo(2));

            VerifyPerson(bad_people[0] as YamlMapping, "Bob", "smells");
            VerifyPerson(bad_people[1] as YamlMapping, "Uma", "too tall");
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

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("good_people"), Is.True,
                "Expected key 'good_people'");

            var good_people = map["good_people"] as YamlSequence;

            Assert.That(good_people, Is.Not.Null);
            Assert.That(good_people.Count, Is.EqualTo(2));

            var mapping = good_people[0] as YamlMapping;

            Assert.That(mapping, Is.Not.Null);
            Assert.That(mapping.ContainsKey("name"), Is.True);
            Assert.That(mapping.ContainsKey("extras"), Is.True);

            var extras = mapping["extras"] as YamlSequence;

            Assert.That(extras, Is.Not.Null);
            Assert.That(extras.Count, Is.EqualTo(1));

            mapping = extras[0] as YamlMapping;

            Assert.That(mapping, Is.Not.Null);
            Assert.That(mapping.ContainsKey("mirror2"), Is.Not.Null);
            Assert.That(mapping["mirror2"].ToString(), Is.EqualTo("one"));
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

            var map = result.Items[0] as YamlMapping;

            Assert.That(map, Is.Not.Null);
            Assert.That(map.ContainsKey("good_people"), Is.True,
                "Expected key 'good_people'");

            var good_people = map["good_people"] as YamlSequence;

            Assert.That(good_people, Is.Not.Null);
            Assert.That(good_people.Count, Is.EqualTo(2));

            var mapping = good_people[0] as YamlMapping;

            Assert.That(mapping, Is.Not.Null);
            Assert.That(mapping.ContainsKey("name"), Is.True);
            Assert.That(mapping.ContainsKey("extras"), Is.True);

            var extras = mapping["extras"] as YamlSequence;

            Assert.That(extras, Is.Not.Null);
            Assert.That(extras.Count, Is.EqualTo(1));

            mapping = extras[0] as YamlMapping;

            Assert.That(mapping, Is.Not.Null);
            Assert.That(mapping.ContainsKey("mirror2"), Is.Not.Null);

            var mirror2Seq = mapping["mirror2"] as YamlSequence;

            Assert.That(mirror2Seq, Is.Not.Null);
            Assert.That(mirror2Seq.Count, Is.EqualTo(2));
            Assert.That(mirror2Seq[0].ToString(), Is.EqualTo("one"));
            Assert.That(mirror2Seq[1].ToString(), Is.EqualTo("two"));
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