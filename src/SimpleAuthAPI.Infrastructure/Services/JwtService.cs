using System;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using SimpleAuthAPI.Application.Abstractions.Settings;

namespace SimpleAuthAPI.Infrastructure.Services;

public class JwtService : IJwtService
{
  private readonly JwtSettings _jwtSettings;
  public JwtService(IOptions<JwtSettings> jwtOptions)
  {
    _jwtSettings = jwtOptions.Value;
  }

  public string GenerateToken(User user)
  {
    var claims = new Claim[]
      {
            new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, user.Email),
            new (JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new (JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
      };

    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

    var securityToken = new JwtSecurityToken(
           _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpiryMinutes),
            signingCredentials: signingCredentials);

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }

  public bool ValidateToken(string token)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

    try
    {
      tokenHandler.ValidateToken(token, new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = _jwtSettings.Issuer,
        ValidateAudience = true,
        ValidAudience = _jwtSettings.Audience,
        ClockSkew = TimeSpan.Zero
      }, out _);

      return true;
    }
    catch
    {
      return false;
    }
  }
}
