using Application.Security.ACL;
using Domain.Security.Services;

namespace Presentation.Security.ACL;

public class SecurityContextFacade : ISecurityContextFacade
{
    private readonly ITokenService _tokenService;

    public SecurityContextFacade(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public int FetchUserIdByToken(string token)
    {
        var user = _tokenService.ValidateToken(token);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid token or user not found.");

        return user.Id;
    }
}