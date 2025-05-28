using FluentValidation;

namespace TreeStructure.API.ViewModels.Node;

public class CreateNodeViewModel
{
    public long? ParentNodeId { get; set; }
    public string TreeName { get; set; }
    public string NodeName { get; set; }
}

public class CreateNodeViewModelValidator : AbstractValidator<CreateNodeViewModel>
{
    public CreateNodeViewModelValidator()
    {
        RuleFor(n => n.TreeName)
            .NotEmpty();

        RuleFor(n => n.NodeName)
            .NotEmpty();
    }
}