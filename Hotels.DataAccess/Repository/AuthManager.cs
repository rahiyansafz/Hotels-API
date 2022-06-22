﻿using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.Models.Dtos.User;
using Hotels.Models.Models;
using Hotels.Models.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hotels.DataAccess.Repository;

public class AuthManager : IAuthManager
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private User _user;

    private const string _loginProvider = "HotelsAPI";
    private const string _refreshToken = "RefreshToken";

    public AuthManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> CreateRefreshToken()
    {
        await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
        var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
        var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);
        return newRefreshToken;
    }

    public async Task<AuthResponse> Login(LoginDto login)
    {
        _user = await _userManager.FindByEmailAsync(login.Email);

        bool isValidUser = await _userManager.CheckPasswordAsync(_user, login.Password);

        if (_user is null || !isValidUser)
            return null;

        var token = await GenerateToken();

        return new AuthResponse
        {
            Token = token,
            UserId = _user.Id
        };
    }

    public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
    {
        _user = _mapper.Map<User>(userDto);

        _user.UserName = userDto.Email;

        var result = await _userManager.CreateAsync(_user, userDto.Password);

        if (result.Succeeded)
            await _userManager.AddToRoleAsync(_user, "User");

        return result.Errors;
    }

    public async Task<AuthResponse> VerifyRefreshToken(AuthResponse request)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);

        var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
        _user = await _userManager.FindByNameAsync(username);

        if (_user is null || _user.Id != request.UserId)
            return null;

        var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

        if (isValidRefreshToken)
        {
            var token = await GenerateToken();
            return new AuthResponse
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };
        }

        await _userManager.UpdateSecurityStampAsync(_user);
        return null;
    }

    private async Task<string> GenerateToken()
    {
        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

        var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        var roles = await _userManager.GetRolesAsync(_user);
        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        var userClaims = await _userManager.GetClaimsAsync(_user);

        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
            }
        .Union(userClaims).Union(roleClaims);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
