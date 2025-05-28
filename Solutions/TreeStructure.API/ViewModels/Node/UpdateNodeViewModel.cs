using FluentValidation;

namespace TreeStructure.API.ViewModels.Node;

public class UpdateNodeViewModel
{
    public long NodeId { get; set; }
    public string TreeName { get; set; }
    public string NewNodeName { get; set; }
}

public class UpdateNodeViewModelValidator : AbstractValidator<UpdateNodeViewModel>
{
    public UpdateNodeViewModelValidator()
    {
        RuleFor(n => n.NodeId)
            .NotEmpty()
            .WithMessage("NodeId is required.");

        RuleFor(n => n.TreeName)
            .NotEmpty();

        RuleFor(n => n.NewNodeName)
            .NotEmpty();
    }
}