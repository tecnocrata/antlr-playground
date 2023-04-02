namespace SnippetCompiler.Library
{
    public class SyntaxErrorResult<T> where T : class, new()
    {
        public T ErrorResult { get; private set; }

        public SyntaxErrorResult()
        {
            this.ErrorResult = new T();
        }
    }
}