using Application.UserStats.ACL;
using Domain.Security.Services;

namespace Application.Security.Features.OutboundServices;
public class UserStatContextService : IUserStatContextService
{
    private IUserStatContextFacade _userStatContextFacade;

    public UserStatContextService(IUserStatContextFacade userStatContextFacade)
    {
        _userStatContextFacade = userStatContextFacade;
    }

    public async Task<bool> CreateUserStat(int userId)
    {
        try
        {
            await _userStatContextFacade.CreateUserStatWithUserId(userId);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
