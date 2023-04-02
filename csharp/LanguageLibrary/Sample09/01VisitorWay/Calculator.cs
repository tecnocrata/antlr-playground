using Antlr4.Runtime;

namespace LanguageLibrary.Sample09._01VisitorWay
{
    public class Calculator
    {
        public void Calculate(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new LExprLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new LExprParser(tokens); // pass column number!
            //parser.BuildParseTree = false; // don't waste time bulding a tree
            var tree = parser.s();

            // create visitor then visit the tree
            var loader = new CalcVisitor();
            var result = loader.Visit(tree);
            Console.WriteLine($"Visitor result {result}");

        }
    }
}
