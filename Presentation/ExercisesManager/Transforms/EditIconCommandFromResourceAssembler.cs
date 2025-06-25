using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

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