using Domain.ExercisesManager.Model.Commands.IconCommands;
using Presentation.ExercisesManager.Resources.IconResources;

namespace Presentation.ExercisesManager.Transforms.IconTransforms;

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