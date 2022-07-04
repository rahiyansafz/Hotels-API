using System.Security.Claims;

namespace Hotels.API.Services;

public interface ICurrentUserService
{
    string? UserId { get; }
}

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor?.HttpContext?.User?.FindFirstValue("uid");
    }

    public string? UserId { get; }
    // Note : You can use RoleName or other props here to claim with this service's interface
}
