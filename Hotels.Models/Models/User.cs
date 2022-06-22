using Microsoft.AspNetCore.Identity;

namespace Hotels.Models.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
