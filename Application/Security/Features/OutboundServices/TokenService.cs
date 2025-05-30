using Domain.Security.Model.Entities;
using Domain.Security.Services;

namespace Application.Security.Features.CommandServices;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public User? ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}