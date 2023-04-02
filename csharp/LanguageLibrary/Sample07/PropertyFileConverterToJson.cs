using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace LanguageLibrary.Sample07
{
    public class PropertyFileConverterToJson
    {
        public void Convert(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new PropertyFileLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PropertyFileParser(tokens); // pass column number!
            //parser.BuildParseTree = false; // don't waste time bulding a tree
            var tree = parser.file();

            // create a standard ANTLR parse tree walker
            ParseTreeWalker walker = new ParseTreeWalker();
            // create listener then feed to walker
            PropertyFileLoader loader = new PropertyFileLoader();
            walker.Walk(loader, tree);        // walk parse tree
            //Console.WriteLine(loader.props); // print results
            foreach (var item in loader.props)
            {
                Console.WriteLine($"{item.Key}={item.Value}");
            }

        }
    }
}
