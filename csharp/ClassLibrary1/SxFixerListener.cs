using Antlr4.Runtime.Misc;

namespace ClassLibrary1
{
    public class SxFixerListener : SXParserBaseListener
    {
        private List<string> UsesList = new List<string>();

        public override void EnterIfStatement([NotNull] SXParser.IfStatementContext context)
        {
            //context.conditional_expression()
            base.EnterIfStatement(context);
        }
    }
}
