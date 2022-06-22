using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.Models.Dtos.User;
using Hotels.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotels.DataAccess.Repository;

public class AuthManager : IAuthManager
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public AuthManager(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<bool> Login(LoginDto login)
    {
        bool isValidUser = false;

        try
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            isValidUser = await _userManager.CheckPasswordAsync(user, login.Password);
        }
        catch (Exception)
        {
        }
        return isValidUser;
    }

    public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        user.UserName = userDto.Email;

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
            await _userManager.AddToRoleAsync(user, "User");

        return result.Errors;
    }
}
