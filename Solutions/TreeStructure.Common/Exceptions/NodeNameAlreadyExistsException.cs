namespace TreeStructure.Common.Exceptions;

public class NodeNameAlreadyExistsException : SecureException
{
    public string Name { get; }

    public NodeNameAlreadyExistsException(string name, string parameters)
        : base($"Node with name '{name}' already exists.", parameters)
    {
        Name = name;
    }
}