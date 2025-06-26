namespace Presentation.ExercisesManager.Resources.Level;

public record EditLevelResource(
    string LevelName,
    string LevelDescription,
    int ExperienceRequiered,
    int TotalQuestions,
    int UnitId,
    int IconId
    );