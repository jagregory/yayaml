using System;
using System.Collections.Generic;
using OMetaSharp;
using YaYAML.Parsing;

namespace YaYAML.Tests
{
    public abstract class AbstractParserTestFixture
    {
        protected T Parse<T>(Func<YamlParser, Rule<char>> ruleFetcher, params string[] lines)
        {
            return ParseInternal(ruleFetcher, lines).As<T>();
        }

        protected IList<T> ParseList<T>(Func<YamlParser, Rule<char>> ruleFetcher, params string[] lines)
        {
            return new List<T>(ParseInternal(ruleFetcher, lines).ToIEnumerable<T>());
        }

        private OMetaList<HostExpression> ParseInternal(Func<YamlParser, Rule<char>> ruleFetcher, params string[] lines)
        {
            if (lines.Length == 1)
                return Grammars.ParseWith(lines[0], ruleFetcher);

            return Grammars.ParseWith(string.Join(Environment.NewLine, lines), ruleFetcher);
        }
    }
}