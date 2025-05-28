using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeStructure.API.ViewModels.Node;
using TreeStructure.BLL.Models.Node;
using TreeStructure.BLL.Services.Interfaces;

namespace TreeStructure.API.Controllers;

[ApiController]
[Route("api.user.tree.node.[action]")]
public class NodeController : ControllerBase
{
    private readonly INodeService _nodeService;
    private readonly IMapper _mapper;

    public NodeController(INodeService nodeService,
        IMapper mapper)
    {
        _nodeService = nodeService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNodeViewModel createNodeViewModel)
    {
        var createNodeModel = _mapper.Map<CreateNodeModel>(createNodeViewModel);

        await _nodeService.CreateAsync(createNodeModel);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateNodeViewModel updateNodeViewModel)
    {
        var updateNodeModel = _mapper.Map<UpdateNodeModel>(updateNodeViewModel);

        await _nodeService.UpdateAsync(updateNodeModel);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteNodeViewModel deleteNodeViewModel)
    {
        await _nodeService.DeleteAsync(deleteNodeViewModel.TreeName, deleteNodeViewModel.NodeId);
        return Ok();
    }
}