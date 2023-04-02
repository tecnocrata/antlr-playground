using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace ClassLibrary1
{
    public class SXErrorListener : BaseErrorListener
    {
        private List<CustomError> Errors { get; set; }

        public bool IsValid { get { return Errors.Any(); } }

        public override void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            //base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            CustomError error = new CustomError();

            if (recognizer.GetType() == typeof(SXParser))
            {
                //error.Stack = (recognizer as SXParser).GetRuleInvocationStackAsString();
                error.Stack = (recognizer as SXParser)?.GetRuleInvocationStack().ToString();
            }

            error.File = Path.GetFileName(e.InputStream.SourceName);

            error.Msg = $"{error.File}: {msg} at {line}:{charPositionInLine}";

            if (offendingSymbol != null)
            {
                error.Symbol = offendingSymbol.Text;
            }

            if (e != null)
            {
                error.Exception = e.GetType().ToString();
            }

            this.Errors.Add(error);
        }


        //public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        //{
        //    CustomError error = new CustomError();

        //    if (recognizer.GetType() == typeof(SXParser))
        //    {
        //        error.Stack = (recognizer as SXParser).GetRuleInvocationStackAsString();
        //    }

        //    error.File = Path.GetFileName(e.InputStream.SourceName);

        //    error.Msg = $"{error.File}: {msg} at {line}:{charPositionInLine}";

        //    if (offendingSymbol != null)
        //    {
        //        error.Symbol = offendingSymbol.Text;
        //    }

        //    if (e != null)
        //    {
        //        error.Exception = e.GetType().ToString();
        //    }

        //    this.Errors.Add(error);
        //}

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            SyntaxError(recognizer, new CommonToken(offendingSymbol), line, charPositionInLine, msg, e);
        }

    }

    public class CustomError
    {
        public string Stack { get; set; } = "";
        public string Symbol { get; set; } = "";
        public string Msg { get; set; } = "";
        public string Exception { get; set; } = "";
        public string File { get; set; } = "";
    }
}
