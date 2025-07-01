using Domain.ExercisesManager.Model.Commands.Level;
using Presentation.ExercisesManager.Resources.Level;

namespace Presentation.ExercisesManager.Transforms.Unit;

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