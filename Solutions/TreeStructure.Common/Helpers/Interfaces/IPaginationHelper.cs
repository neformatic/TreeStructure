using TreeStructure.Common.Models;

namespace TreeStructure.Common.Helpers.Interfaces;

public interface IPaginationHelper
{
    Task<PaginationResultModel<T>> GeneratePaginationResultModelAsync<T>(IQueryable<T> items, int pageNumber, int pageItemsCount);
}