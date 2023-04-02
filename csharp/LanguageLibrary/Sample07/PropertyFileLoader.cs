using Antlr4.Runtime.Misc;

namespace LanguageLibrary.Sample07
{
    public class PropertyFileLoader : PropertyFileBaseListener
    {
        public Dictionary<string, string> props = new Dictionary<string, string>();

        public override void ExitProp([NotNull] PropertyFileParser.PropContext context)
        {
            //base.ExitProp(context);
            var id = context.ID().GetText();
            var value = context.STRING().GetText();
            props[id] = value;
        }
    }
}
