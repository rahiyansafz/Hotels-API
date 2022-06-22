using Hotels.Models.Dtos.User;
using Hotels.Models.Models;
using Hotels.Models.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace Hotels.DataAccess.Contracts;

public interface IAuthManager
{
    Task<IEnumerable<IdentityError>> Register(UserDto user);
    Task<AuthResponse> Login(LoginDto login);
}
