namespace Application.Shared.Features.OutboundServices.ACL;

public interface IExternalSecurityService
{
    int? GetCurrentUserId();
}