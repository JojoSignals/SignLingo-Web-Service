using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class CreateLevelCommandFromResourceAssembler
{
    public static CreateLevelCommand ToCommandFromResource(CreateLevelResource resource)
    {
        return new CreateLevelCommand(
            resource.LevelName,
            resource.LevelDescription,
            resource.ExperienceRequiered,
            resource.TotalQuestions,
            resource.UnitId,
            resource.IconId
        );
    }
}