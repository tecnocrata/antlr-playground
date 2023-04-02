using Antlr4.Runtime.Misc;

namespace LanguageLibrary.Sample01
{
    public class ArrayInitTranslatorListener : ArrayInitBaseListener
    {
        public override void EnterInit([NotNull] ArrayInitParser.InitContext context)
        {
            //base.EnterInit(context);
            Console.Write("\"");
        }

        public override void ExitInit([NotNull] ArrayInitParser.InitContext context)
        {
            Console.Write("\"");
            //base.ExitInit(context);
        }

        public override void EnterValue([NotNull] ArrayInitParser.ValueContext context)
        {
            // assumes NO nested array initializer
            var value = Convert.ToInt32(context.INT().GetText());
            Console.Write("\\u{0:x4}", value);
            //base.EnterValue(context);
        }
    }
}
