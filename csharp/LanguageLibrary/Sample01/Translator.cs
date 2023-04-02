using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace LanguageLibrary.Sample01
{
    public class Translator
    {
        public void Translate(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new ArrayInitLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ArrayInitParser(tokenStream);

            lexer.RemoveErrorListeners();
            parser.RemoveErrorListeners();
            //var customErrorListener = new SXErrorListener();
            //parser.AddErrorListener(customErrorListener);
            //var visitor = new SnippetLanguageVisitor();
            var listener = new ArrayInitTranslatorListener();

            var adaptableExpression = parser.init();
            ParseTreeWalker walker = new ParseTreeWalker();
            walker.Walk(listener, adaptableExpression);

        }
    }
}
