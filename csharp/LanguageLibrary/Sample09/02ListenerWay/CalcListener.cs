using Antlr4.Runtime.Misc;

namespace LanguageLibrary.Sample09._02ListenerWay
{
    public class CalcListener : LExprBaseListener
    {
        public Stack<int> _stack = new Stack<int>();

        public override void ExitMult([NotNull] LExprParser.MultContext context)
        {
            //base.ExitMult(context);
            int right = _stack.Pop();
            int left = _stack.Pop();
            _stack.Push(right * left);
        }

        public override void ExitAdd([NotNull] LExprParser.AddContext context)
        {
            //base.ExitAdd(context);
            int right = _stack.Pop();
            int left = _stack.Pop();
            _stack.Push(right + left);
        }

        public override void ExitInt([NotNull] LExprParser.IntContext context)
        {
            //base.ExitInt(context);
            _stack.Push(Convert.ToInt32(context.INT().GetText()));
        }
    }
}
