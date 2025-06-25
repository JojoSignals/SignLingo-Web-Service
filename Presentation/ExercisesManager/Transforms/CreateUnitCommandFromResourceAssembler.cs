using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class CreateUnitCommandFromResourceAssembler
{
    public static CreateUnitCommand ToCommandFromResource(CreateUnitResource resource)
    {
        return new CreateUnitCommand(resource.Name);
    }
}