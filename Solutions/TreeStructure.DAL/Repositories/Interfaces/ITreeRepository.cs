using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL.Repositories.Interfaces;

public interface ITreeRepository
{
    Task CreateAsync(Tree tree);
    Task<Tree> GetTreeAsync(string name);
}