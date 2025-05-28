using Microsoft.EntityFrameworkCore;
using TreeStructure.DAL.Entities;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.DAL.Repositories;

public class TreeRepository : ITreeRepository
{
    private readonly TreeStructureDbContext _dbContext;

    public TreeRepository(TreeStructureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tree> GetTreeAsync(string name)
    {
        return await _dbContext.Trees
            .Include(t => t.Nodes)
            .ThenInclude(n => n.Children)
            .FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task CreateAsync(Tree tree)
    {
        await _dbContext.Trees.AddAsync(tree);
    }
}