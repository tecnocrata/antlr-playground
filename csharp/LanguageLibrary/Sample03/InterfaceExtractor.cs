using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace LanguageLibrary.Sample03
{
    public class InterfaceExtractor
    {
        public void Extractor(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new JavaLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new JavaParser(tokens);
            var tree = parser.compilationUnit(); //parse

            var walker = new ParseTreeWalker();
            var listener = new InterfaceExtractorListener(parser, tokens);
            walker.Walk(listener, tree);
        }
    }
}
