using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Resources.Level;

public record LevelResource(
    string LevelName,
    string LevelDescription,
    int ExperienceRequired,
    int TotalQuestions,
    UnitResource Unit,
    IconResource Icon
);