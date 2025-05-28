namespace TreeStructure.DAL.Entities;

public class Tree
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Node> Nodes { get; set; } = [];
}