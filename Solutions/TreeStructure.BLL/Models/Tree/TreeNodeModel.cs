namespace TreeStructure.BLL.Models.Tree;

public class TreeNodeModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<TreeNodeModel> Children { get; set; }
}