using Common.Application.FluentValidations;
using FluentValidation;

namespace TodoList.Application.User.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {

            RuleFor(f => f.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");

        }
    }
}
