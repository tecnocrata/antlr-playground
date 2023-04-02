using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace LanguageLibrary.Sample09._03AnnotationListenerWay
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


            // create a standard ANTLR parse tree walker
            ParseTreeWalker walker = new ParseTreeWalker();
            // create listener then feed to walker
            var loader = new CalcAnnotatorListener();
            walker.Walk(loader, tree);        // walk parse tree
            var result = loader.GetValue(tree);
            Console.WriteLine($"Annnotator Listener result {result}");

        }
    }
}
