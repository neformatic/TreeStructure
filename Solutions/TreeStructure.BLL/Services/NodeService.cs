using TreeStructure.BLL.Models.Node;
using TreeStructure.BLL.Models.Tree;
using TreeStructure.BLL.Services.Interfaces;
using TreeStructure.Common.Exceptions;
using TreeStructure.DAL;
using TreeStructure.DAL.Entities;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.BLL.Services;

public class NodeService : INodeService
{
    private readonly INodeRepository _nodeRepository;
    private readonly ITreeService _treeService;
    private readonly TreeStructureDbContext _dbContext;

    public NodeService(
        INodeRepository nodeRepository,
        ITreeService treeService,
        TreeStructureDbContext dbContext)
    {
        _nodeRepository = nodeRepository;
        _treeService = treeService;
        _dbContext = dbContext;
    }

    public async Task CreateAsync(CreateNodeModel createNodeModel)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            var tree = await _treeService.GetExistingTreeWithoutCreatingAsync(createNodeModel.TreeName);

            if (createNodeModel.ParentNodeId.HasValue)
            {
                await GetValidatedNodeAsync(tree, createNodeModel.ParentNodeId.Value, createNodeModel.TreeName);
            }

            if (await ExistsWithSameNameAsync(createNodeModel.ParentNodeId, createNodeModel.NodeName))
            {
                var parameters = $"treeName={createNodeModel.TreeName}, parentId={createNodeModel.ParentNodeId}, name={createNodeModel.NodeName}";
                throw new NodeNameAlreadyExistsException(createNodeModel.NodeName, parameters);
            }

            var newNode = new Node
            {
                Name = createNodeModel.NodeName,
                TreeId = tree.Id,
                ParentId = createNodeModel.ParentNodeId
            };

            await _nodeRepository.CreateAsync(newNode);
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task UpdateAsync(UpdateNodeModel updateNodeModel)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            var tree = await _treeService.GetExistingTreeWithoutCreatingAsync(updateNodeModel.TreeName);

            var validatedNode = await GetValidatedNodeAsync(tree, updateNodeModel.NodeId, updateNodeModel.TreeName);

            if (await ExistsWithSameNameAsync(validatedNode.ParentId, updateNodeModel.NewNodeName))
            {
                var parameters = $"treeName={updateNodeModel.TreeName}, parentId={updateNodeModel.NodeId}, name={updateNodeModel.NewNodeName}";
                throw new NodeNameAlreadyExistsException(updateNodeModel.NewNodeName, parameters);
            }

            validatedNode.Name = updateNodeModel.NewNodeName;

            await _nodeRepository.UpdateAsync(validatedNode);
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteAsync(string treeName, long nodeId)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            var tree = await _treeService.GetExistingTreeWithoutCreatingAsync(treeName);
            var validatedNode = await GetValidatedNodeAsync(tree, nodeId, treeName);

            if (validatedNode.Children.Any())
            {
                var parameters = $"treeName={treeName}, nodeId={nodeId}";
                throw new NodeHasChildrenException(nodeId, parameters);
            }

            await _nodeRepository.DeleteAsync(validatedNode);
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task<bool> ExistsWithSameNameAsync(long? parenId, string nodeName)
    {
        return await _nodeRepository.ExistsWithSameNameAsync(parenId, nodeName);
    }

    private async Task<Node> GetValidatedNodeAsync(TreeNodeModel tree, long nodeId, string treeName)
    {
        var parameters = $"treeName={treeName}, nodeId={nodeId}";

        var node = await _nodeRepository.GetByIdAsync(nodeId);

        if (node == null)
        {
            throw new NodeNotFoundException(nodeId, parameters);
        }

        if (node.TreeId != tree.Id)
        {
            throw new NodeInWrongTreeException(tree.Id, nodeId, parameters);
        }

        return node;
    }
}