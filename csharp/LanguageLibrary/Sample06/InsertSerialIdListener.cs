using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using LanguageLibrary.Sample03;

namespace LanguageLibrary.Sample06
{
    public class InsertSerialIdListener : JavaBaseListener
    {
        private TokenStreamRewriter rewriter;
        public InsertSerialIdListener(ITokenStream tokens)
        {
            rewriter = new TokenStreamRewriter(tokens);
        }

        public override void EnterClassBody([NotNull] JavaParser.ClassBodyContext context)
        {
            var field = "\n\tpublic static final long serialVersionUID = 1L;";
            rewriter.InsertAfter(context.start, field);
        }

        public string TransformedCode { get { return this.rewriter.GetText(); } }
    }
}
