using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace LanguageLibrary.Sample03
{
    public class InterfaceExtractorListener : JavaBaseListener
    {
        private JavaParser parser;
        private CommonTokenStream tokens;
        public InterfaceExtractorListener(JavaParser parser, CommonTokenStream tokens)
        {
            this.parser = parser;
            this.tokens = tokens;
        }

        public override void EnterClassDeclaration([NotNull] JavaParser.ClassDeclarationContext context)
        {
            //base.EnterClassDeclaration(context);
            Console.WriteLine("interface I" + context.Identifier().GetText() + "{");
        }

        public override void ExitClassDeclaration([NotNull] JavaParser.ClassDeclarationContext context)
        {
            //base.ExitClassDeclaration(context);
            Console.WriteLine("}");
        }

        public override void EnterMethodDeclaration([NotNull] JavaParser.MethodDeclarationContext context)
        {
            // The next block doesn't extract correctly the params
            //var type = "void";
            //if (context.type() != null)
            //{
            //    type = context.type().GetText();
            //}
            //var args = context.formalParameters().GetText();
            //var identifier = context.Identifier().GetText();

            //var tokens = parser.InputStream; 
            //https://stackoverflow.com/questions/70701595/is-there-a-way-to-extract-tokens-in-order-with-antlr
            var type = "void";
            if (context.type() != null)
            {
                type = tokens.GetText(context.type());
            }
            var args = tokens.GetText(context.formalParameters());
            var identifier = context.Identifier().GetText();
            Console.WriteLine($"\t{type} {identifier} {args};");
        }

        public override void EnterImportDeclaration([NotNull] JavaParser.ImportDeclarationContext context)
        {
            //base.EnterImportDeclaration(context);
            Console.WriteLine(this.tokens.GetText(context)); // ALL the import declaration
        }
    }
}
