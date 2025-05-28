namespace TreeStructure.BLL.Models.Node;

public class CreateNodeModel
{
    public string TreeName { get; set; }
    public long? ParentNodeId { get; set; }
    public string NodeName { get; set; }
}