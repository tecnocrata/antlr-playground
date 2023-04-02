using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ClassLibrary1
{
    public class SnippetTranspilerVisitor : SnippetLanguageParserBaseVisitor<string>
    {
        //public string Start(ParserRuleContext ctx)
        //{
        //    return this.VisitProgram(ctx);
        //}

        public override string VisitTerminal([NotNull] ITerminalNode node)
        {
            //return base.VisitTerminal(node);

            return node.GetText();
        }
    }
}
