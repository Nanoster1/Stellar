using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

using MediatR;

using Stellar.IS.Application.Users.Queries.GetUserById;
using Stellar.IS.WebApi.IdentityServer.Services.Interfaces;

namespace Stellar.IS.WebApi.IdentityServer.Services.Implementations;

public class StellarProfileService : IProfileService
{
    private readonly ISender _sender;
    private readonly IClaimsProvider _claimsProvider;

    public StellarProfileService(ISender sender, IClaimsProvider claimsProvider)
    {
        _sender = sender;
        _claimsProvider = claimsProvider;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        if (context.RequestedClaimTypes.Any())
        {
            var userId = GetUserId(context);
            var query = new GetUserByIdQuery(userId);

            var result = await _sender.Send(query);
            if (result.IsError) return;

            var claims = _claimsProvider.GetClaimsFromUserModel(result.Value);
            context.AddRequestedClaims(claims);
        }
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var userId = GetUserId(context);
        var query = new GetUserByIdQuery(userId);

        var result = await _sender.Send(query);
        if (result.IsError)
        {
            context.IsActive = false;
            return;
        }

        var user = result.Value;
        context.IsActive = user.IsActive;
    }

    private static Guid GetUserId(ProfileDataRequestContext context)
    {
        var id = context.Subject.GetSubjectId();
        return Guid.Parse(id);
    }

    private static Guid GetUserId(IsActiveContext context)
    {
        var id = context.Subject.GetSubjectId();
        return Guid.Parse(id);
    }
}