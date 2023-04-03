using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserSimpleValidator : AbstractValidator<UserDto>
    {
        public UserSimpleValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Status).Must(x => x == false || x == true);

        }
    }
}
