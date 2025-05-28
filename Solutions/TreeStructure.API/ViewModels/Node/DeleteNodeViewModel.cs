using FluentValidation;

namespace TreeStructure.API.ViewModels.Node;

public class DeleteNodeViewModel
{
    public string TreeName { get; set; }
    public long NodeId { get; set; }
}

public class DeleteNodeViewModelValidator : AbstractValidator<DeleteNodeViewModel>
{
    public DeleteNodeViewModelValidator()
    {
        RuleFor(n => n.TreeName)
            .NotEmpty();

        RuleFor(n => n.NodeId)
            .NotEmpty()
            .WithMessage("NodeId is required.");
    }
}