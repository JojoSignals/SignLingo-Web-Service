namespace Presentation.ExercisesManager.Resources;

public record CreateLevelResource(
    string LevelName,
    string LevelDescription,
    int ExperienceRequiered,
    int TotalQuestions,
    int UnitId,
    int IconId
    );