using Domain.ExercisesManager.Model.Commands.Level;
using Presentation.ExercisesManager.Resources.Level;

namespace Presentation.ExercisesManager.Transforms.Level;

public static class CreateLevelCommandFromResourceAssembler
{
    public static CreateLevelCommand ToCommandFromResource(CreateLevelResource resource)
    {
        return new CreateLevelCommand(
            resource.LevelName,
            resource.LevelDescription,
            resource.ExperienceRequired,
            resource.TotalQuestions,
            resource.UnitId,
            resource.IconId
        );
    }
}