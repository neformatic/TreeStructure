using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeStructure.API.ViewModels.Tree;
using TreeStructure.BLL.Services.Interfaces;

namespace TreeStructure.API.Controllers;

[ApiController]
[Route("api.user.tree.[action]")]
public class TreeController : ControllerBase
{
    private readonly ITreeService _treeService;
    private readonly IMapper _mapper;

    public TreeController(ITreeService treeService,
        IMapper mapper)
    {
        _treeService = treeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string treeName)
    {
        var treeNodeModel = await _treeService.GetTreeAsync(treeName);
        var treeNodeViewModels = _mapper.Map<TreeNodeViewModel>(treeNodeModel);

        return Ok(treeNodeViewModels);
    }
}