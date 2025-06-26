using Domain.ExercisesManager.Model.Commands.Unit;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Transforms.Unit;

public static class CreateUnitCommandFromResourceAssembler
{
    public static CreateUnitCommand ToCommandFromResource(CreateUnitResource resource)
    {
        return new CreateUnitCommand(resource.Name);
    }
}