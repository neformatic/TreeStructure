using Microsoft.EntityFrameworkCore;
using TreeStructure.Common.Helpers.Interfaces;
using TreeStructure.Common.Models;

namespace TreeStructure.Common.Helpers;

public class PaginationHelper : IPaginationHelper
{
    public async Task<PaginationResultModel<T>> GeneratePaginationResultModelAsync<T>(IQueryable<T> items, int pageNumber, int pageItemsCount)
    {
        var totalItemsCount = await items.CountAsync();

        var paginatedItems = await items
            .Skip((pageNumber - 1) * pageItemsCount)
            .Take(pageItemsCount)
            .ToListAsync();

        return new PaginationResultModel<T>
        {
            ResultsCount = totalItemsCount,
            PagesCount = CalculatePagesCount(totalItemsCount, pageItemsCount),
            PageNumber = pageNumber,
            PageItems = paginatedItems
        };
    }

    private int CalculatePagesCount(long totalItemsCount, int pageItemsCount)
    {
        return (int)Math.Ceiling((double)totalItemsCount / pageItemsCount);
    }
}