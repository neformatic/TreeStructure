namespace TreeStructure.API.ViewModels.Tree;

public class TreeNodeViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<TreeNodeViewModel> Children { get; set; }
}