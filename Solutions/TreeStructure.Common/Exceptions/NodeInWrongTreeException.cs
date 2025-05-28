namespace TreeStructure.Common.Exceptions;

public class NodeInWrongTreeException : SecureException
{
    public long TreeId { get; }
    public long NodeId { get; }

    public NodeInWrongTreeException(long treeId, long nodeId, string parameters)
        : base($"Node '{nodeId}' does not belong to the specified tree.", parameters)
    {
        TreeId = treeId;
        NodeId = nodeId;
    }
}