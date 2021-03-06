using System.IO;
using OMetaSharp;

namespace YaYAML.Utils.RebuildParser
{
    public class OMetaCodeGenerator
    {
        public void RebuildParser()
        {
            var contents = File.ReadAllText(@"..\..\..\YaYAML\Parsing\YamlParser.ometacs");
            var result = Grammars.ParseGrammarThenOptimizeThenTranslate
                <OMetaParser, OMetaOptimizer, OMetaTranslator>
                (contents,
                 p => p.Grammar,
                 o => o.OptimizeGrammar,
                 t => t.Trans);

            File.WriteAllText(@"..\..\..\YaYAML\Parsing\YamlParser.cs", result);
        }
    }
}