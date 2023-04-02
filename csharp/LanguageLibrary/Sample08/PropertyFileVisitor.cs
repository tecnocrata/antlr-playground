using Antlr4.Runtime.Misc;
using LanguageLibrary.Sample07;

namespace LanguageLibrary.Sample08
{
    public class PropertyFileVisitor : PropertyFileBaseVisitor<string>
    {
        public Dictionary<string, string> props = new Dictionary<string, string>();

        public override string VisitProp([NotNull] PropertyFileParser.PropContext context)
        {
            //return base.VisitProp(context);
            var id = context.ID().GetText();
            var value = context.STRING().GetText();
            props[id] = value;
            // The visitors need to call Visit method in order to continue walking thru the tree
            // In this case, the nodes created for prop invocations don’t have children, so visitProp doesn’t have to call visit.
            return String.Empty; // We don't want and need returnig anything
        }
    }
}
