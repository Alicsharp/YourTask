using Common.Application.FluentValidations;
using FluentValidation;

namespace TodoList.Application.User.Edit
{
    internal partial class EditUserCommandHandler
    {
        public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
        {
            public EditUserCommandValidator()
            {
                RuleFor(r => r.PhoneNumber)
                    .ValidPhoneNumber();

                RuleFor(r => r.Email)
                    .EmailAddress().WithMessage("ایمیل نامعتبر است");

 
            }
        }
    }
}
