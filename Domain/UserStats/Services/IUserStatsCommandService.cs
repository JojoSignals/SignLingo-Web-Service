using Domain.UserStats.Model.Commands;
using Domain.UserStats.Model.Responses;

namespace Domain.UserStats.Services;

public interface IUserStatsCommandService
{
    Task<UserStatsResponse> Handle(CreateUserStatsCommand command);
    Task<UserStatsResponse> Handle(UpdateUserStatsCommand command);
    Task<bool> Handle(DeleteUserStatsCommand command);
}