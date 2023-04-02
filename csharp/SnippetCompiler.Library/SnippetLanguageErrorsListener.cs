using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace SnippetCompiler.Library
{
    public class SnippetLanguageErrorsListener : BaseErrorListener
    {
        public bool IsValid { get; private set; } = true;
        public SyntaxErrorResult<List<SyntaxError>> Errors { get; private set; }

        public SnippetLanguageErrorsListener()
        {
            Errors = new SyntaxErrorResult<List<SyntaxError>>();
        }


        //public override void ReportAmbiguity(
        //  Parser recognizer, DFA dfa,
        //  int startIndex, int stopIndex,
        //  bool exact, BitSet ambigAlts,
        //  ATNConfigSet configs)
        //{
        //    IsValid = false;
        //}

        //public override void ReportAttemptingFullContext(
        //  Parser recognizer, DFA dfa,
        //  int startIndex, int stopIndex,
        //  BitSet conflictingAlts, SimulatorState conflictState)
        //{
        //    IsValid = false;
        //}

        //public override void ReportContextSensitivity(
        //  Parser recognizer, DFA dfa,
        //  int startIndex, int stopIndex,
        //  int prediction, SimulatorState acceptState)
        //{
        //    IsValid = false;
        //}

        public override void SyntaxError(
          IRecognizer recognizer, IToken offendingSymbol,
          int line, int charPositionInLine,
         string msg, RecognitionException e)
        {
            this.IsValid = false;
            Errors.ErrorResult.Add(new SyntaxError(charPositionInLine, msg));
        }
    }

    public class SnippetLanguageThrowingErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        public override void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            //base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            //throw new ParseCanceledException("line " + line + ":" + charPositionInLine + " " + msg);
            Console.WriteLine("line " + line + ":" + charPositionInLine + " " + msg);
        }

        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            //throw new ParseCanceledException("line " + line + ":" + charPositionInLine + " " + msg);
            Console.WriteLine("line " + line + ":" + charPositionInLine + " " + msg);
        }

        //==== more

        //public override void ReportAttemptingFullContext([NotNull] Parser recognizer, [NotNull] DFA dfa, int startIndex, int stopIndex, [Nullable] BitSet conflictingAlts, [NotNull] SimulatorState conflictState)
        //{
        //    Console.WriteLine("line " + line + ":" + charPositionInLine + " " + msg);
        //    //base.ReportAttemptingFullContext(recognizer, dfa, startIndex, stopIndex, conflictingAlts, conflictState);
        //}
    }
}