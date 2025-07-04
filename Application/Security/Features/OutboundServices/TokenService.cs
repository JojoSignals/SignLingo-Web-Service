using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Security.Model.Entities;
using Domain.Security.Model.ValueObjects;
using Domain.Security.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Application.Security.Features.OutboundServices;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var keyBytes = Encoding.UTF8.GetBytes(_configuration["Auth:SecretKey"] ?? string.Empty);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256)
        };

        return new JwtSecurityTokenHandler()
            .WriteToken(new JwtSecurityTokenHandler()
                .CreateToken(tokenDescriptor));
    }


    public User? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;


        var key = Encoding.UTF8.GetBytes(_configuration["Auth:SecretKey"]);

        var tokenHandler = new JwtSecurityTokenHandler();
        var parameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, parameters, out var validatedToken);

            var userId = int.Parse(principal.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);
            var username = principal.FindFirst(JwtRegisteredClaimNames.Name)!.Value;
            var role = principal.FindFirst(ClaimTypes.Role)!.Value;

            return new User
            {
                Id = userId,
                Username = username,
                Role = (UserRoles)Enum.Parse(typeof(UserRoles), role)
            };
        }
        catch
        {
            return null;
        }
    }
}