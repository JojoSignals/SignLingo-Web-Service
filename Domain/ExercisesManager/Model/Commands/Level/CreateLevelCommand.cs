namespace Domain.ExercisesManager.Model.Commands.Level;

public record CreateLevelCommand(
    string LevelName,
    string LevelDescription,
    int ExperienceRequiered,
    int TotalQuestions,
    int UnitId,
    int IconId
    );