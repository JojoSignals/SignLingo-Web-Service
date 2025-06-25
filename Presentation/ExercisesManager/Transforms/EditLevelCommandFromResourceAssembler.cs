using Domain.ExercisesManager.Model.Commands;
using Presentation.ExercisesManager.Resources;

namespace Presentation.ExercisesManager.Transforms;

public static class EditLevelCommandFromResourceAssembler
{
    public static EditLevelCommand ToCommandFromResource(int id, EditLevelResource resource)
    {
        return new EditLevelCommand(
            id,
            resource.LevelName,
            resource.LevelDescription,
            resource.ExperienceRequiered,
            resource.TotalQuestions,
            resource.UnitId,
            resource.IconId
        );
    }
}