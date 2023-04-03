using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.OperationClaimId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
    public class UserOperationClaimSimpleValidator : AbstractValidator<UserOperationClaimDto>
    {
        public UserOperationClaimSimpleValidator()
        {
            RuleFor(p => p.OperationClaimId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();

        }
    }
}
