using System.Security.Claims;

namespace Api.Core.Services.UserService;

public interface IUserService
{
    public ClaimsPrincipal GetCurrentUser();
    public Guid GetUserId();
}