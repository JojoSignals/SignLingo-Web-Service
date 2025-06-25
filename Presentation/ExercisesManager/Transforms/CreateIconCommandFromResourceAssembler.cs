using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class CreateIconCommandFromResourceAssembler
{
    public static CreateIconCommand ToCommandFromResource(CreateIconResource resource)
    {
        return new CreateIconCommand(resource.UrlImage);
    }
}