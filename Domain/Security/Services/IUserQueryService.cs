using Domain.Security.Model.Queries;
using Domain.Security.Model.Responses;

namespace Domain.Security.Services;

public interface IUserQueryService
{
    Task <IReadOnlyCollection<UserResponse>> Handle(GetAllUsersQuery query);
    Task<UserResponse?> Handle(GetUserByIdQuery query);
    Task<UserResponse?> Handle(GetUserByEmailQuery query);
    Task<UserResponse?> Handle(GetUserByUsernameQuery query);
    
}