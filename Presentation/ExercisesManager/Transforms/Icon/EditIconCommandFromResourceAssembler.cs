using Domain.ExercisesManager.Model.Commands.IconCommands;
using Presentation.ExercisesManager.Resources.Icon;

namespace Presentation.ExercisesManager.Transforms.Icon;

public static class EditIconCommandFromResourceAssembler
{
    public static EditIconCommand ToCommandFromResource(int id, EditIconResource resource)
    {
        return new EditIconCommand(
            id,
            resource.UrlImage
        );
    }
}