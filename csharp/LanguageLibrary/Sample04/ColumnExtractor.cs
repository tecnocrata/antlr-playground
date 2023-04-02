using Antlr4.Runtime;

namespace LanguageLibrary.Sample04
{
    public class ColumnExtractor
    {
        public void Extract(string content, int column)
        {
            var inputStream = new AntlrInputStream(content);
            var lexer = new RowsLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new RowsParser(tokens, column); // pass column number!
            parser.BuildParseTree = false; // don't waste time bulding a tree
            parser.file();
        }
    }
}
