using FluentValidation;
using TreeStructure.Common.Constants;

namespace TreeStructure.API.ViewModels.Common;

public class BasePaginationFilterViewModel
{
    public int PageNumber { get; set; }
    public int PageItemsCount { get; set; }
}

public class BasePaginationFilterViewModelValidator<T> : AbstractValidator<T> where T : BasePaginationFilterViewModel
{
    public BasePaginationFilterViewModelValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(PageConstants.MinPageNumber);

        RuleFor(x => x.PageItemsCount)
            .GreaterThanOrEqualTo(PageConstants.MinPageItems);
    }
}