using Application.UserStats.ACL;
using Domain.UserStats.Model.Commands;
using Domain.UserStats.Services;

namespace Presentation.UserStats.ACL;
public class UserStatContextFacade : IUserStatContextFacade
{
    private readonly IUserStatsCommandService _userStatsCommandService;

    public UserStatContextFacade(IUserStatsCommandService userStatsCommandService)
    {
        this._userStatsCommandService = userStatsCommandService;
    }

    public async Task CreateUserStatWithUserId(int userId)
    {
        var command = new CreateUserStatsCommand(userId);

        await _userStatsCommandService.Handle(command);
    }
}
