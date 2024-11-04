using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Todo.Item.Create
{
    public class AddTodoItemValidator : AbstractValidator<AddToDoItemCommand>
    {
        public AddTodoItemValidator()
        {
            RuleFor(f => f.Title).Empty().WithMessage("Title is Empty");
            RuleFor(f => f.Description).Empty().WithMessage("Description is Empty");
        }
    }
}
