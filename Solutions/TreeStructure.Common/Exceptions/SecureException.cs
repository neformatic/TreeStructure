namespace TreeStructure.Common.Exceptions;

public class SecureException : Exception
{
    public string Parameters { get; set; }

    public SecureException(string message, string parameters = null) : base(message)
    {
        Parameters = parameters;
    }
}