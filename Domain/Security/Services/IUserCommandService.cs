using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Model.Responses;

namespace Domain.Security.Services;

public interface IUserCommandService
{
    Task<(UserResponse user, string token)> Handle(SignInCommand command);
    Task <UserResponse> Handle(SignUpCommand command);
    Task <UserResponse> Handle(int id, UpdateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
    Task<bool> Handle(UpdateUserPictureCommand command);
}