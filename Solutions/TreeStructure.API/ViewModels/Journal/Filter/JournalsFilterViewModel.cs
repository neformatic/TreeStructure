using FluentValidation;
using TreeStructure.API.ViewModels.Common;

namespace TreeStructure.API.ViewModels.Journal.Filter;

public class JournalsFilterViewModel : BasePaginationFilterViewModel
{
    public DateTimeOffset? CreatedAtFrom { get; set; }
    public DateTimeOffset? CreatedAtTo { get; set; }
    public string SearchCriteria { get; set; }
}

public class JournalsFilterViewModelValidator : BasePaginationFilterViewModelValidator<JournalsFilterViewModel>
{
    public JournalsFilterViewModelValidator()
    {
        RuleFor(j => j.CreatedAtFrom)
            .Must(j => j <= DateTime.UtcNow)
            .When(j => j.CreatedAtFrom.HasValue)
            .WithMessage("'CreatedAtFrom' cannot be in the future.");

        RuleFor(j => j.CreatedAtTo)
            .Must(j => j <= DateTime.UtcNow)
            .When(j => j.CreatedAtTo.HasValue)
            .WithMessage("'CreatedAtTo' cannot be in the future.");

        RuleFor(j => j)
            .Must(j => j.CreatedAtFrom <= j.CreatedAtTo)
            .When(j => j.CreatedAtFrom.HasValue && j.CreatedAtTo.HasValue)
            .WithMessage("'CreatedAtFrom' cannot be later than 'CreatedAtTo'.");
    }
}