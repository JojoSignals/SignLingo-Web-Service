using Domain.UserStats.Model.Queries;
using Domain.UserStats.Model.Responses;

namespace Domain.UserStats.Services;

public interface IUserStatsQueryService
{
    Task<UserStatsResponse?> Handle(GetUserStatsByUserIdQuery query);
    Task<IReadOnlyCollection<UserStatsResponse>> Handle(GetAllUserStatsQuery query);
}