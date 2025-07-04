using System.Security.Claims;
using Application.Shared.Features.OutboundServices.ACL;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Presentation.Shared.ACL;

public class ExternalSecurityService : IExternalSecurityService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExternalSecurityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public int? GetCurrentUserId()
    {
        var claim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
     
        Console.WriteLine("Claim: " + claim?.Value);
        return !string.IsNullOrEmpty(claim?.Value) ? int.Parse(claim.Value) : null;
    }
    
}