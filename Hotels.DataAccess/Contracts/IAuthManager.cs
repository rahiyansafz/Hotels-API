using Hotels.Models.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace Hotels.DataAccess.Contracts;

public interface IAuthManager
{
    Task<IEnumerable<IdentityError>> Register(UserDto user);
}
