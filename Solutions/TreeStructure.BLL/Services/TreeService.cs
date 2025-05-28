using TreeStructure.BLL.Models.Tree;
using TreeStructure.BLL.Services.Interfaces;
using TreeStructure.Common.Exceptions;
using TreeStructure.DAL;
using TreeStructure.DAL.Entities;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.BLL.Services;

public class TreeService : ITreeService
{
    private readonly ITreeRepository _treeRepository;
    private readonly TreeStructureDbContext _dbContext;

    public TreeService(ITreeRepository treeRepository,
        TreeStructureDbContext dbContext)
    {
        _treeRepository = treeRepository;
        _dbContext = dbContext;
    }

    public async Task<TreeNodeModel> GetTreeAsync(string treeName)
    {
        var tree = await _treeRepository.GetTreeAsync(treeName);

        if (tree == null)
        {
            tree = new Tree { Name = treeName };

            await _treeRepository.CreateAsync(tree);
            await _dbContext.SaveChangesAsync();
        }

        var rootNodes = tree.Nodes.Where(n => n.ParentId == null).ToList();

        var treeNodeModel = new TreeNodeModel
        {
            Id = tree.Id,
            Name = tree.Name,
            Children = MapChildren(rootNodes)
        };

        return treeNodeModel;
    }

    public async Task<TreeNodeModel> GetExistingTreeWithoutCreatingAsync(string treeName)
    {
        var tree = await _treeRepository.GetTreeAsync(treeName);

        if (tree == null)
        {
            var parameters = $"treeName={treeName}";
            throw new TreeNotFoundException(treeName, parameters);
        }

        return new TreeNodeModel
        {
            Id = tree.Id,
            Name = tree.Name
        };
    }

    private List<TreeNodeModel> MapChildren(List<Node> nodes)
    {
        var children = nodes.Select(node => new TreeNodeModel
        {
            Id = node.Id,
            Name = node.Name,
            Children = MapChildren(node.Children)
        }).ToList();

        return children;
    }
}