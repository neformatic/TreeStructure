using TreeStructure.BLL.Models.Tree;

namespace TreeStructure.BLL.Services.Interfaces;

public interface ITreeService
{
    Task<TreeNodeModel> GetTreeAsync(string treeName);
    Task<TreeNodeModel> GetExistingTreeWithoutCreatingAsync(string treeName);
}