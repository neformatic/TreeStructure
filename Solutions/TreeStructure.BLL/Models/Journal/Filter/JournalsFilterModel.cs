using TreeStructure.Common.Models;

namespace TreeStructure.BLL.Models.Journal.Filter;

public class JournalsFilterModel : BasePaginationFilterModel
{
    public DateTimeOffset? CreatedAtFrom { get; set; }
    public DateTimeOffset? CreatedAtTo { get; set; }
    public string SearchCriteria { get; set; }
}