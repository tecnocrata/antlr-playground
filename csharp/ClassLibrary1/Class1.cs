using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ClassLibrary1
{
    public class Class1 : SnippetLanguageParserBaseListener
    {
        public override void EnterIfSentence([NotNull] SnippetLanguageParser.IfSentenceContext context)
        {
            base.EnterIfSentence(context);
        }

        public override void VisitTerminal([NotNull] ITerminalNode node)
        {
            base.VisitTerminal(node);
        }

        public override void ExitIfSentence([NotNull] SnippetLanguageParser.IfSentenceContext context)
        {
            base.ExitIfSentence(context);
        }

    }

    public class Class2 : SnippetLanguageParserBaseVisitor<string>
    {

    }
}