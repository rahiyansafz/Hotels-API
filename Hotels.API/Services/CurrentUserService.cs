using System.Security.Claims;

namespace Hotels.API.Services;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserRole { get; }
}

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor?.HttpContext?.User?.FindFirstValue("uid");
        UserRole = httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
    }

    public string? UserId { get; }
    public string? UserRole { get; }
    // Note : You can use RoleName or other props here to claim with this service's interface
}
