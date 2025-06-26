namespace Presentation.ExercisesManager.Resources.Level;

public record CreateLevelResource(
    string LevelName,
    string LevelDescription,
    int ExperienceRequiered,
    int TotalQuestions,
    int UnitId,
    int IconId
    );