namespace Domain.ExercisesManager.Model.Commands;

public record EditLevelCommand(
    int Id,
    string LevelName,
    string LevelDescription,
    int ExperienceRequiered,
    int TotalQuestions,
    int UnitId,
    int IconId
    );