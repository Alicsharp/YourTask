using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.FluentValidations
{
    public static class FluentValidations
    {
        public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidPhoneNumber)
        {
            return ruleBuilder.Custom((phoneNumber, context) =>
            {
                if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length is < 11 or > 11)
                    context.AddFailure(errorMessage);

            });
        }
    }
}
