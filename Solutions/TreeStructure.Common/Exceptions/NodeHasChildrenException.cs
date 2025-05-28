namespace TreeStructure.Common.Exceptions;

public class NodeHasChildrenException : SecureException
{
    public long NodeId { get; }

    public NodeHasChildrenException(long nodeId, string parameters)
        : base("You have to delete all children nodes first.", parameters)
    {
        NodeId = nodeId;
    }
}