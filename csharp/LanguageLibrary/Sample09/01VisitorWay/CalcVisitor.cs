using Antlr4.Runtime.Misc;

namespace LanguageLibrary.Sample09._01VisitorWay
{
    public class CalcVisitor : LExprBaseVisitor<int>
    {
        public override int VisitMult([NotNull] LExprParser.MultContext context)
        {
            //return base.VisitMult(context);
            return this.Visit(context.e(0)) * this.Visit(context.e(1));
        }

        public override int VisitAdd([NotNull] LExprParser.AddContext context)
        {
            //return base.VisitAdd(context);
            return this.Visit(context.e(0)) + this.Visit(context.e(1));
        }

        public override int VisitInt([NotNull] LExprParser.IntContext context)
        {
            //return base.VisitInt(context);
            //return this.Visit(context.INT());
            return Convert.ToInt32(context.INT().GetText());
        }
    }
}
