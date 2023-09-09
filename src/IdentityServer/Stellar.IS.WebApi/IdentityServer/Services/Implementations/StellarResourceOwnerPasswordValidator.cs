using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;

using MediatR;

using NSpecifications;

using Stellar.IS.Application.Users.Queries.ValidateUserPassword;

namespace Stellar.IS.WebApi.IdentityServer.Services.Implementations;

public class StellarResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly ISender _sender;

    public StellarResourceOwnerPasswordValidator(ISender sender)
    {
        _sender = sender;
    }

    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var query = new ValidateUserPasswordQuery(context.UserName, context.Password);
        var result = await _sender.Send(query);

        if (result.IsError)
        {
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "invalid password");
        }
        else
        {
            context.Result = new GrantValidationResult(
                            subject: "818727",
                            authenticationMethod: "custom");
        }
    }
}
