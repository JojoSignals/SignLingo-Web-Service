using Domain.ExercisesManager.Model.Commands.Level;
using Presentation.ExercisesManager.Resources.Level;

namespace Presentation.ExercisesManager.Transforms.Unit;

public static class CreateLevelCommandFromResourceAssembler
{
    public static CreateLevelCommand ToCommandFromResource(CreateLevelResource resource)
    {
        return new CreateLevelCommand(
            resource.Name,
            resource.ExperienceRequired,
            resource.UnitId,
            resource.IconId
        );
    }
}