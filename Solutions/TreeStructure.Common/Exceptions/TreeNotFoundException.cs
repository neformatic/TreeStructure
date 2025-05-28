namespace TreeStructure.Common.Exceptions;

public class TreeNotFoundException : SecureException
{
    public string TreeName { get; }

    public TreeNotFoundException(string treeName, string parameters)
        : base($"Tree with name '{treeName}' not found.", parameters)
    {
        TreeName = treeName;
    }
}