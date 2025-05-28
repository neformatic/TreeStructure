using AutoMapper;
using TreeStructure.BLL.Models.Journal;
using TreeStructure.BLL.Models.Journal.Filter;
using TreeStructure.BLL.Services.Interfaces;
using TreeStructure.Common.Exceptions;
using TreeStructure.Common.Helpers.Interfaces;
using TreeStructure.Common.Models;
using TreeStructure.DAL;
using TreeStructure.DAL.Entities;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.BLL.Services;

public class JournalService : IJournalService
{
    private readonly IJournalRepository _journalRepository;
    private readonly TreeStructureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IPaginationHelper _paginationHelper;

    public JournalService(IJournalRepository journalRepository,
        TreeStructureDbContext dbContext,
        IMapper mapper,
        IPaginationHelper paginationHelper)
    {
        _journalRepository = journalRepository;
        _dbContext = dbContext;
        _mapper = mapper;
        _paginationHelper = paginationHelper;
    }

    public async Task<JournalModel> CreateAsync(Exception ex, string parameters)
    {
        var journal = new Journal
        {
            EventId = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.UtcNow,
            Text = ex.Message,
            Parameters = parameters,
            StackTrace = ex.StackTrace ?? "No stack trace available"
        };

        await _journalRepository.CreateAsync(journal);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<JournalModel>(journal);
    }

    public async Task<PaginationResultModel<JournalInfoModel>> GetRangeAsync(JournalsFilterModel filterModel)
    {
        var journalsQuery = _journalRepository.GetJournalsAsQueryable();

        journalsQuery = FilterJournalsQuery(filterModel, journalsQuery);

        var orderedQuery = journalsQuery
            .OrderByDescending(j => j.CreatedAt)
            .Select(j => new JournalInfoModel
            {
                Id = j.Id,
                EventId = j.EventId,
                CreatedAt = j.CreatedAt
            });

        var result = await _paginationHelper.GeneratePaginationResultModelAsync(
            orderedQuery,
            filterModel.PageNumber,
            filterModel.PageItemsCount
        );

        return result;
    }

    public async Task<JournalModel> GetSingleAsync(long id)
    {
        var journal = await _journalRepository.GetSingleAsync(id);

        if (journal == null)
        {
            throw new SecureException("Entity was not found", $"id={id}");
        }

        var journalModel = _mapper.Map<JournalModel>(journal);

        return journalModel;
    }

    private IQueryable<Journal> FilterJournalsQuery(JournalsFilterModel filterModel, IQueryable<Journal> journalsQuery)
    {
        if (filterModel.CreatedAtFrom.HasValue)
        {
            journalsQuery = journalsQuery.Where(j => j.CreatedAt >= filterModel.CreatedAtFrom.Value);
        }

        if (filterModel.CreatedAtTo.HasValue)
        {
            journalsQuery = journalsQuery.Where(j => j.CreatedAt <= filterModel.CreatedAtTo.Value);
        }

        if (!string.IsNullOrWhiteSpace(filterModel.SearchCriteria))
        {
            journalsQuery = journalsQuery.Where(j => j.Text.Contains(filterModel.SearchCriteria)
                                                     || j.Parameters.Contains(filterModel.SearchCriteria));
        }

        return journalsQuery;
    }
}