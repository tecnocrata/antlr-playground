using Antlr4.Runtime.Misc;

namespace LanguageLibrary.Sample02
{
    public class MyExprVisitor : ExprBaseVisitor<double>
    {
        private Dictionary<string, double> Memory { get; set; } = new Dictionary<string, double>();

        // ID '=' expr NEWLINE
        public override double VisitAssign([NotNull] ExprParser.AssignContext context)
        {
            var id = context.ID().GetText();
            var value = Visit(context.expr());
            Memory.Add(id, value);
            return value;
        }

        // expr NEWLINE
        public override double VisitPrintExpr([NotNull] ExprParser.PrintExprContext context)
        {
            //return base.VisitPrintExpr(context);
            var value = Visit(context.expr());
            Console.WriteLine(value);
            return 0; //dummy value
        }

        // INT 
        public override double VisitInt([NotNull] ExprParser.IntContext context)
        {
            //return base.VisitInt(context);
            return Convert.ToDouble(context.INT().GetText());
        }

        //ID
        public override double VisitId([NotNull] ExprParser.IdContext context)
        {
            //return base.VisitId(context);
            var id = context.ID().GetText();
            if (Memory.ContainsKey(id)) { return Memory[id]; }
            return 0;
        }

        // expr op=(''|'/') expr 
        public override double VisitMulDiv([NotNull] ExprParser.MulDivContext context)
        {
            //return base.VisitMulDiv(context);
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            var op = context.op.Type;
            if (op == ExprParser.MUL)
            {
                return left * right;
            }

            return left / right;
        }

        // expr op=('+'|'-') expr
        public override double VisitAddSub([NotNull] ExprParser.AddSubContext context)
        {
            //return base.VisitAddSub(context);
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            var op = context.op.Type;
            if (op == ExprParser.ADD)
            {
                return left + right;
            }

            return left - right;
        }

        // '(' expr ')'
        public override double VisitParens([NotNull] ExprParser.ParensContext context)
        {
            //return base.VisitParens(context);
            return Visit(context.expr());
        }

    }
}
