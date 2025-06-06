using Domain.Security.Model.Commands;
using Presentation.Security.Resources;

namespace Presentation.Security.Transform;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource (int id, UpdateUserResource resource)
    {
        return new UpdateUserCommand(id, resource.Username, resource.ProfilePicture, resource.CurrentPassword, resource.NewPassword);
    }
}