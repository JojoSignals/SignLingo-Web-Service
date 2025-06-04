using Domain.Security.Model.Commands;
using Presentation.Security.Resources;

namespace Presentation.Security.Transform;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource (UpdateUserResource resource)
    {
        return new UpdateUserCommand(resource.Id, resource.Username, resource.ProfilePicture, resource.CurrentPassword, resource.NewPassword);
    }
}