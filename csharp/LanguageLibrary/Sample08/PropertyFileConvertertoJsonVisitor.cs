using Antlr4.Runtime;
using LanguageLibrary.Sample07;

namespace LanguageLibrary.Sample08
{
    public class PropertyFileConvertertoJsonVisitor
    {
        public void Convert(string content)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new PropertyFileLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PropertyFileParser(tokens); // pass column number!
            //parser.BuildParseTree = false; // don't waste time bulding a tree
            var tree = parser.file();

            // create visitor then visit the tree
            PropertyFileVisitor loader = new PropertyFileVisitor();
            loader.Visit(tree);
            foreach (var item in loader.props)
            {
                Console.WriteLine($"{item.Key}={item.Value}");
            }

        }
    }
}
