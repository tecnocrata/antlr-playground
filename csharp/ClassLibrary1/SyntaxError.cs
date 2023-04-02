namespace ClassLibrary1
{
    public class SyntaxError
    {
        public int ErrorLocation { get; private set; } = -1;
        public string ErrorMessage { get; private set; } = "";

        public SyntaxError(int errorLocation, string errorMessage)
        {
            ErrorLocation = errorLocation;
            ErrorMessage = errorMessage;
        }
    }
}