using TreeStructure.BLL.Models.Journal;
using TreeStructure.BLL.Models.Journal.Filter;
using TreeStructure.Common.Models;

namespace TreeStructure.BLL.Services.Interfaces;

public interface IJournalService
{
    Task<JournalModel> CreateAsync(Exception ex, string parameters);
    Task<JournalModel> GetSingleAsync(long id);
    Task<PaginationResultModel<JournalInfoModel>> GetRangeAsync(JournalsFilterModel filterModel);
}