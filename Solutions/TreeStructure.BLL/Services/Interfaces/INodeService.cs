using TreeStructure.BLL.Models.Node;

namespace TreeStructure.BLL.Services.Interfaces;

public interface INodeService
{
    Task CreateAsync(CreateNodeModel createNodeModel);
    Task UpdateAsync(UpdateNodeModel updateNodeModel);
    Task DeleteAsync(string treeName, long nodeId);
}