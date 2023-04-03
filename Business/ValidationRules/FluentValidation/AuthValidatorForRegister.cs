using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidatorForRegister : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidatorForRegister()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.LastName).MinimumLength(2);
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(2);


        }
    }
    public class AuthValidatorForLogin : AbstractValidator<UserForLoginDto>
    {
        public AuthValidatorForLogin()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(2);
        }
    }
}
