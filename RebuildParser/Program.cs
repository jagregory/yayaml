using System.Runtime.InteropServices;

namespace YaYAML.Utils.RebuildParser
{
    class Program
    {
        static void Main()
        {
            var generator = new OMetaCodeGenerator();
            
            generator.RebuildParser();
        }
    }
}