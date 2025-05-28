using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeStructure.API.ViewModels.Journal;
using TreeStructure.API.ViewModels.Journal.Filter;
using TreeStructure.BLL.Models.Journal.Filter;
using TreeStructure.BLL.Services.Interfaces;
using TreeStructure.Common.Models;

namespace TreeStructure.API.Controllers;

[ApiController]
[Route("api.user.journal.[action]")]
public class JournalController : ControllerBase
{
    private readonly IJournalService _journalService;
    private readonly IMapper _mapper;

    public JournalController(IJournalService journalService,
        IMapper mapper)
    {
        _journalService = journalService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRange([FromQuery] JournalsFilterViewModel filterViewModel)
    {
        var filterModel = _mapper.Map<JournalsFilterModel>(filterViewModel);

        var paginatedJournalInfoModel = await _journalService.GetRangeAsync(filterModel);
        var paginatedJournalInfoViewModel = _mapper.Map<PaginationResultModel<JournalInfoViewModel>>(paginatedJournalInfoModel);

        return Ok(paginatedJournalInfoViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetSingle([FromQuery] long id)
    {
        var journalModel = await _journalService.GetSingleAsync(id);
        var journalViewModel = _mapper.Map<JournalViewModel>(journalModel);

        return Ok(journalViewModel);
    }
}