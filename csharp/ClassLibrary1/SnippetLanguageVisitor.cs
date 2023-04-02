using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ClassLibrary1
{
    public class SnippetLanguageVisitor : SnippetLanguageParserBaseVisitor<string>
    {
        public override string VisitErrorNode([NotNull] IErrorNode node)
        {
            //Console.WriteLine(node..ToString());
            return base.VisitErrorNode(node);
        }
    }
}
