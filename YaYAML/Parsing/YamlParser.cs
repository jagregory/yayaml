using OMetaSharp;
using YaYAML;

namespace YaYAML.Parsing
{
    public class YamlParser : Parser
    {
        public virtual bool Document(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> m = null;
            OMetaList<HostExpression> s = null;
            modifiedStream = inputStream;
            if(!MetaRules.Or(modifiedStream, out result, out modifiedStream,
            delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(
                    delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                    {
                        modifiedStream3 = inputStream3;
                        if(!MetaRules.Apply(Mapping, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        m = result3;
                        result3 = ( new YamlDocument(m.As<YamlMapping>()) ).AsHostExpressionList();
                        return MetaRules.Success();
                    }, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ,delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(
                    delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                    {
                        modifiedStream3 = inputStream3;
                        if(!MetaRules.Apply(Sequence, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        s = result3;
                        result3 = ( new YamlDocument(s.As<YamlSequence>()) ).AsHostExpressionList();
                        return MetaRules.Success();
                    }, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool Mapping(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> pairs = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.Many1(
                        delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                        {
                            modifiedStream3 = inputStream3;
                            if(!MetaRules.Apply(MappingPair, modifiedStream3, out result3, out modifiedStream3))
                            {
                                return MetaRules.Fail(out result3, out modifiedStream3);
                            }
                            return MetaRules.Success();
                        }
                    , modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    pairs = result2;
                    result2 = ( new YamlMapping(pairs.ToIEnumerable<YamlMappingPair>()) ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool MappingKey(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> key = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.Many1(
                        delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                        {
                            modifiedStream3 = inputStream3;
                            if(!MetaRules.Apply(
                                delegate(OMetaStream<char> inputStream4, out OMetaList<HostExpression> result4, out OMetaStream <char> modifiedStream4)
                                {
                                    modifiedStream4 = inputStream4;
                                    if(!MetaRules.Not(
                                        delegate(OMetaStream<char> inputStream5, out OMetaList<HostExpression> result5, out OMetaStream <char> modifiedStream5)
                                        {
                                            modifiedStream5 = inputStream5;
                                            if(!MetaRules.ApplyWithArgs(Exactly, modifiedStream5, out result5, out modifiedStream5, (":").AsHostExpressionList()))
                                            {
                                                return MetaRules.Fail(out result5, out modifiedStream5);
                                            }
                                            return MetaRules.Success();
                                        }
                                    , modifiedStream4, out result4, out modifiedStream4))
                                    {
                                        return MetaRules.Fail(out result4, out modifiedStream4);
                                    }
                                    if(!MetaRules.Not(
                                        delegate(OMetaStream<char> inputStream5, out OMetaList<HostExpression> result5, out OMetaStream <char> modifiedStream5)
                                        {
                                            modifiedStream5 = inputStream5;
                                            if(!MetaRules.Apply(NewLine, modifiedStream5, out result5, out modifiedStream5))
                                            {
                                                return MetaRules.Fail(out result5, out modifiedStream5);
                                            }
                                            return MetaRules.Success();
                                        }
                                    , modifiedStream4, out result4, out modifiedStream4))
                                    {
                                        return MetaRules.Fail(out result4, out modifiedStream4);
                                    }
                                    if(!MetaRules.Apply(Character, modifiedStream4, out result4, out modifiedStream4))
                                    {
                                        return MetaRules.Fail(out result4, out modifiedStream4);
                                    }
                                    return MetaRules.Success();
                                }, modifiedStream3, out result3, out modifiedStream3))
                            {
                                return MetaRules.Fail(out result3, out modifiedStream3);
                            }
                            return MetaRules.Success();
                        }
                    , modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    key = result2;
                    if(!MetaRules.ApplyWithArgs(Exactly, modifiedStream2, out result2, out modifiedStream2, (":").AsHostExpressionList()))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    result2 = ( key ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool MappingPair(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> key = null;
            OMetaList<HostExpression> value = null;
            modifiedStream = inputStream;
            if(!MetaRules.Or(modifiedStream, out result, out modifiedStream,
            delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(
                    delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                    {
                        modifiedStream3 = inputStream3;
                        if(!MetaRules.Apply(MappingKey, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        key = result3;
                        if(!MetaRules.Apply(NewLine, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        if(!MetaRules.Apply(MultilineText, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        value = result3;
                        result3 = ( new YamlMappingPair(key.As<string>(), value.As<string>()) ).AsHostExpressionList();
                        return MetaRules.Success();
                    }, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ,delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(
                    delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                    {
                        modifiedStream3 = inputStream3;
                        if(!MetaRules.Apply(MappingKey, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        key = result3;
                        if(!MetaRules.Apply(Spaces, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        if(!MetaRules.Apply(Text, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        value = result3;
                        if(!MetaRules.Apply(OptNewLine, modifiedStream3, out result3, out modifiedStream3))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        result3 = ( new YamlMappingPair(key.As<string>(), value.As<string>()) ).AsHostExpressionList();
                        return MetaRules.Success();
                    }, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool Sequence(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> items = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.Many1(
                        delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                        {
                            modifiedStream3 = inputStream3;
                            if(!MetaRules.Apply(SequenceItem, modifiedStream3, out result3, out modifiedStream3))
                            {
                                return MetaRules.Fail(out result3, out modifiedStream3);
                            }
                            return MetaRules.Success();
                        }
                    , modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    items = result2;
                    result2 = ( new YamlSequence(items.ToIEnumerable<YamlSequenceItem>()) ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool SequenceItem(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> text = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.ApplyWithArgs(Exactly, modifiedStream2, out result2, out modifiedStream2, ("-").AsHostExpressionList()))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    if(!MetaRules.Apply(Space, modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    if(!MetaRules.Apply(Text, modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    text = result2;
                    if(!MetaRules.Apply(OptNewLine, modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    result2 = ( new YamlSequenceItem(text.As<string>()) ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool MultilineText(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> lines = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.Many1(
                        delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                        {
                            modifiedStream3 = inputStream3;
                            if(!MetaRules.Apply(MultilineTextLine, modifiedStream3, out result3, out modifiedStream3))
                            {
                                return MetaRules.Fail(out result3, out modifiedStream3);
                            }
                            return MetaRules.Success();
                        }
                    , modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    lines = result2;
                    result2 = ( lines.Join(" ") ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool MultilineTextLine(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> s = null;
            OMetaList<HostExpression> text = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.Many1(
                        delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                        {
                            modifiedStream3 = inputStream3;
                            if(!MetaRules.Apply(Space, modifiedStream3, out result3, out modifiedStream3))
                            {
                                return MetaRules.Fail(out result3, out modifiedStream3);
                            }
                            return MetaRules.Success();
                        }
                    , modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    s = result2;
                    if(!MetaRules.Apply(Text, modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    text = result2;
                    if(!MetaRules.Apply(OptNewLine, modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    result2 = ( text.As<string>() ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool Text(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            OMetaList<HostExpression> t = null;
            modifiedStream = inputStream;
            if(!MetaRules.Apply(
                delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
                {
                    modifiedStream2 = inputStream2;
                    if(!MetaRules.Many1(
                        delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                        {
                            modifiedStream3 = inputStream3;
                            if(!MetaRules.Apply(
                                delegate(OMetaStream<char> inputStream4, out OMetaList<HostExpression> result4, out OMetaStream <char> modifiedStream4)
                                {
                                    modifiedStream4 = inputStream4;
                                    if(!MetaRules.Not(
                                        delegate(OMetaStream<char> inputStream5, out OMetaList<HostExpression> result5, out OMetaStream <char> modifiedStream5)
                                        {
                                            modifiedStream5 = inputStream5;
                                            if(!MetaRules.Apply(NewLine, modifiedStream5, out result5, out modifiedStream5))
                                            {
                                                return MetaRules.Fail(out result5, out modifiedStream5);
                                            }
                                            return MetaRules.Success();
                                        }
                                    , modifiedStream4, out result4, out modifiedStream4))
                                    {
                                        return MetaRules.Fail(out result4, out modifiedStream4);
                                    }
                                    if(!MetaRules.Apply(Character, modifiedStream4, out result4, out modifiedStream4))
                                    {
                                        return MetaRules.Fail(out result4, out modifiedStream4);
                                    }
                                    return MetaRules.Success();
                                }, modifiedStream3, out result3, out modifiedStream3))
                            {
                                return MetaRules.Fail(out result3, out modifiedStream3);
                            }
                            return MetaRules.Success();
                        }
                    , modifiedStream2, out result2, out modifiedStream2))
                    {
                        return MetaRules.Fail(out result2, out modifiedStream2);
                    }
                    t = result2;
                    result2 = ( t.As<string>() ).AsHostExpressionList();
                    return MetaRules.Success();
                }, modifiedStream, out result, out modifiedStream))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool NewLine(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            modifiedStream = inputStream;
            if(!MetaRules.Or(modifiedStream, out result, out modifiedStream,
            delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(
                    delegate(OMetaStream<char> inputStream3, out OMetaList<HostExpression> result3, out OMetaStream <char> modifiedStream3)
                    {
                        modifiedStream3 = inputStream3;
                        if(!MetaRules.ApplyWithArgs(Exactly, modifiedStream3, out result3, out modifiedStream3, ("\r").AsHostExpressionList()))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        if(!MetaRules.ApplyWithArgs(Exactly, modifiedStream3, out result3, out modifiedStream3, ("\n").AsHostExpressionList()))
                        {
                            return MetaRules.Fail(out result3, out modifiedStream3);
                        }
                        return MetaRules.Success();
                    }, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ,delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.ApplyWithArgs(Exactly, modifiedStream2, out result2, out modifiedStream2, ("\n").AsHostExpressionList()))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
        public virtual bool OptNewLine(OMetaStream<char> inputStream, out OMetaList<HostExpression> result, out OMetaStream <char> modifiedStream)
        {
            modifiedStream = inputStream;
            if(!MetaRules.Or(modifiedStream, out result, out modifiedStream,
            delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(NewLine, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ,delegate(OMetaStream<char> inputStream2, out OMetaList<HostExpression> result2, out OMetaStream <char> modifiedStream2)
            {
                modifiedStream2 = inputStream2;
                if(!MetaRules.Apply(Empty, modifiedStream2, out result2, out modifiedStream2))
                {
                    return MetaRules.Fail(out result2, out modifiedStream2);
                }
                return MetaRules.Success();
            }
            ))
            {
                return MetaRules.Fail(out result, out modifiedStream);
            }
            return MetaRules.Success();
        }
    }
}
