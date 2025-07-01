using Domain.Security.Model.Commands;
using Presentation.Security.Resources;

public static class UpdateUserPictureCommandFromResourceAssembler
{
    public static UpdateUserPictureCommand ToCommandFromResource(int id, UpdateUserPictureResource resource)
    {
        return new UpdateUserPictureCommand(
            id,
            resource.File.OpenReadStream()
        );
    }
}