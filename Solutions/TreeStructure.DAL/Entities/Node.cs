namespace TreeStructure.DAL.Entities;

public class Node
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long TreeId { get; set; }
    public long? ParentId { get; set; }

    public Tree Tree { get; set; }
    public Node Parent { get; set; }
    public List<Node> Children { get; set; } = [];
}