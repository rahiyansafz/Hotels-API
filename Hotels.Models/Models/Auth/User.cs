using Microsoft.AspNetCore.Identity;

namespace Hotels.Models.Models.Auth;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
