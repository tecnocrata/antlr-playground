using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace LanguageLibrary.Sample09._03AnnotationListenerWay
{
    public class CalcAnnotatorListener : LExprBaseListener
    {
        /** maps nodes to integers with Map<ParseTree,Integer> */
        ParseTreeProperty<int> values = new ParseTreeProperty<int>();

        public int GetValue(IParseTree node) { return values.Get(node); }
        public void SetValue(IParseTree node, int value) { values.Put(node, value); }

        // For me this way is similar to use a Stack
        public override void ExitMult([NotNull] LExprParser.MultContext context)
        {
            //base.ExitMult(context);
            int right = GetValue(context.e(1));
            int left = GetValue(context.e(0));
            //_stack.Push(right * left);
            SetValue(context, left * right);
        }

        public override void ExitAdd([NotNull] LExprParser.AddContext context)
        {
            //base.ExitAdd(context);
            int right = GetValue(context.e(1));//_stack.Pop();
            int left = GetValue(context.e(0));//_stack.Pop();
            //_stack.Push(right + left);
            SetValue(context, left + right);
        }

        public override void ExitInt([NotNull] LExprParser.IntContext context)
        {
            //base.ExitInt(context);
            //_stack.Push(Convert.ToInt32(context.INT().GetText()));
            var value = Convert.ToInt32(context.INT().GetText());
            SetValue(context, value);
        }

        //THIS is the only new different method from the previous example
        public override void ExitS([NotNull] LExprParser.SContext context)
        {
            //base.ExitS(context);
            SetValue(context, GetValue(context.e()));
        }
    }
}
