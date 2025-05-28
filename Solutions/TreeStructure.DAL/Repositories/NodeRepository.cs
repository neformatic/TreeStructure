using Microsoft.EntityFrameworkCore;
using TreeStructure.DAL.Entities;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.DAL.Repositories;

public class NodeRepository : INodeRepository
{
    private readonly TreeStructureDbContext _dbContext;

    public NodeRepository(TreeStructureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Node> GetByIdAsync(long nodeId)
    {
        return await _dbContext.Nodes
            .Include(n => n.Tree)
            .Include(n => n.Children)
            .FirstOrDefaultAsync(n => n.Id == nodeId);
    }

    public async Task<bool> ExistsWithSameNameAsync(long? parentId, string name)
    {
        return await _dbContext.Nodes
            .AnyAsync(n => n.ParentId == parentId && n.Name == name);
    }

    public async Task CreateAsync(Node node)
    {
        await _dbContext.Nodes.AddAsync(node);
    }

    public Task UpdateAsync(Node node)
    {
        _dbContext.Nodes.Update(node);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Node node)
    {
        _dbContext.Nodes.Remove(node);
        return Task.CompletedTask;
    }
}