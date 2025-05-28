using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL.Repositories.Interfaces;

public interface INodeRepository
{
    Task<Node> GetByIdAsync(long nodeId);
    Task<bool> ExistsWithSameNameAsync(long? parentId, string name);
    Task CreateAsync(Node node);
    Task UpdateAsync(Node node);
    Task DeleteAsync(Node node);
}