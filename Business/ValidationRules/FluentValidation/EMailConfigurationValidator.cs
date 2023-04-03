using Core.Entities.Concrete.DBEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class EMailConfigurationValidator : AbstractValidator<MailConfig>
    {
        public EMailConfigurationValidator()
        {
            RuleFor(p => p.Port).NotEmpty();
            RuleFor(p => p.EnableSsl).Must(x => x == false || x == true);
            RuleFor(p => p.From).NotEmpty();
            RuleFor(p => p.From).EmailAddress();
            RuleFor(p => p.Password).NotEmpty().MinimumLength(2); ;
            RuleFor(p => p.SmtpServer).NotEmpty();
            RuleFor(p => p.To).NotEmpty();

        }
    }
}
