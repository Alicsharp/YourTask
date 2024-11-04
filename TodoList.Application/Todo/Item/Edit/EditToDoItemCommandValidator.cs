using FluentValidation;

namespace TodoList.Application.Todo.Item.Edit
{
    public class EditToDoItemCommandValidator : AbstractValidator<EditToDoItemCommand>
    {
        public EditToDoItemCommandValidator()
        {
            RuleFor(f => f.Title).Empty().WithMessage("Title is Empty");
            RuleFor(f => f.Description).Empty().WithMessage("Description is Empty");
        }
    }
}
