using Antlr4.Runtime;

namespace ClassLibrary1
{
    //Transpiler
    // Probably rename it to SxTranspiler
    public class SxFixer
    {
        public Tuple<string, List<string>> FixCode(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new SXLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new SXParser(tokenStream);

            lexer.RemoveErrorListeners();
            parser.RemoveErrorListeners();
            var customErrorListener = new SXErrorListener();
            parser.AddErrorListener(customErrorListener);
            var visitor = new SnippetLanguageVisitor();

            var adaptableExpression = parser.program();
            //ParseTreeWalker walker = new ParseTreeWalker();
            //walker.Walk(<no error listener>, adaptableExpression);
            var result = visitor.Visit(adaptableExpression);
            var isValid = customErrorListener.IsValid;
            //var errorLocation = customErrorListener.ErrorLocation;
            //var errorMessage = customErrorListener.ErrorMessage;
            if (result != null)
            {
                isValid = false;
            }
            return null;
        }
    }
}
