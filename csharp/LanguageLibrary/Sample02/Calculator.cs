using Antlr4.Runtime;

namespace LanguageLibrary.Sample02
{
    public class Calculator
    {
        public double Calulate(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new ExprLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ExprParser(tokenStream);

            lexer.RemoveErrorListeners();
            parser.RemoveErrorListeners();

            var tree = parser.prog();
            var eval = new MyExprVisitor();
            return eval.Visit(tree);
        }
    }
}
