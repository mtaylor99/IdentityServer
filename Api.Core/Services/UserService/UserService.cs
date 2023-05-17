using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Api.Core.Services.UserService;

internal class UserService : IUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Guid GetUserId()
    {
        return GetGuidClaim("sub");
    }

    public ClaimsPrincipal GetCurrentUser()
    {
        return _contextAccessor.HttpContext?.User;
    }

    private Guid GetGuidClaim(string claimType)
    {
        var claim = GetCurrentUser().Claims
            .SingleOrDefault(e => e.Type == claimType)?.Value;

        return !string.IsNullOrWhiteSpace(claim) && Guid.TryParse(claim, out var id)
            ? id
            : Guid.Empty;
    }
}