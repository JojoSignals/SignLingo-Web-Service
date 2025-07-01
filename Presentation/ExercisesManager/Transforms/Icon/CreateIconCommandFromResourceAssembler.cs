using Domain.ExercisesManager.Model.Commands.IconCommands;
using Presentation.ExercisesManager.Resources.Icon;

namespace Presentation.ExercisesManager.Transforms.Icon;

public static class CreateIconCommandFromResourceAssembler
{
    public static CreateIconCommand ToCommandFromResource(CreateIconResource resource)
    {
        return new CreateIconCommand(resource.Image.OpenReadStream());
    }
}