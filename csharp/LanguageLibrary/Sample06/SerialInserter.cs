using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using LanguageLibrary.Sample03;

namespace LanguageLibrary.Sample06
{
    public class SerialInserter
    {
        public string Insert(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new JavaLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new JavaParser(tokens);
            var tree = parser.compilationUnit(); //parse

            var walker = new ParseTreeWalker();
            var listener = new InsertSerialIdListener(tokens);
            walker.Walk(listener, tree);
            return listener.TransformedCode;
        }
    }
}
