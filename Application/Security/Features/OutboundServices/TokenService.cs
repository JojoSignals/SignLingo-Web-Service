using System.Security.Claims;
using System.Text;
using Domain.Security.Model.Entities;
using Domain.Security.Services;
using Microsoft.Extensions.Configuration;

namespace Application.Security.Features.CommandServices;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public User? ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}