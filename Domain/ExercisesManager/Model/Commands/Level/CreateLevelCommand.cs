namespace Domain.ExercisesManager.Model.Commands.Level;

public record CreateLevelCommand(
    string Name,
    int ExperienceRequired,
    int UnitId,
    int IconId
    );