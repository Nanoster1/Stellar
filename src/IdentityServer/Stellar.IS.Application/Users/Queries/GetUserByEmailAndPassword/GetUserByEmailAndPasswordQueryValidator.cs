using FluentValidation;

namespace Stellar.IS.Application.Users.Queries.ValidateUserPassword;

public class GetUserByEmailAndPasswordQueryValidator : AbstractValidator<ValidateUserPasswordQuery>
{
    public GetUserByEmailAndPasswordQueryValidator()
    {
        RuleFor(q => q.Password).NotEmpty();
    }
}
