using Domain.ExercisesManager.Model.Commands.IconCommands;
using Presentation.ExercisesManager.Resources.IconResources;

namespace Presentation.ExercisesManager.Transforms.IconTransforms;

public static class CreateIconCommandFromResourceAssembler
{
    public static CreateIconCommand ToCommandFromResource(CreateIconResource resource)
    {
        return new CreateIconCommand(resource.UrlImage);
    }
}