namespace SnippetCompiler.Library
{
    public class ParserResult
    {
        public bool IsValid { get; internal set; }
        public int ErrorPosition { get; internal set; } = -1;
        public string ErrorMessage { get; internal set; }
        public string Result { get; internal set; }
    }

    public class ParserResult<T> where T : class, new()
    {
        public bool IsValid { get; internal set; }
        //public int ErrorPosition { get; internal set; } = -1;
        //public string ErrorMessage { get; internal set; }
        public T ErrorResult { get; private set; }
        public string Result { get; internal set; }

        public ParserResult()
        {
            ErrorResult = new T();
        }

        public void AddError(T error)
        {
            ErrorResult = error;
        }
    }
}