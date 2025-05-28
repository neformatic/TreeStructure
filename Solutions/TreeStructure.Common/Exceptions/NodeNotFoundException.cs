namespace TreeStructure.Common.Exceptions;

public class NodeNotFoundException : SecureException
{
    public long NodeId { get; }

    public NodeNotFoundException(long nodeId, string parameters)
        : base($"Node with ID '{nodeId}' not found.", parameters)
    {
        NodeId = nodeId;
    }
}