using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace SnippetCompiler.Library.grammars
{
    public class SnippetLanguageVisitor : SnippetLanguageBaseVisitor<string>
    {
        public override string VisitErrorNode([NotNull] IErrorNode node)
        {
            //Console.WriteLine(node..ToString());
            return base.VisitErrorNode(node);
        }
    }
}
