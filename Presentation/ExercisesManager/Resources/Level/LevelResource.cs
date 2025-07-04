using Presentation.ExercisesManager.Resources.Exercise;
using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Resources.Level;

public record LevelResource(
    int Id,
    string Name,
    int ExperienceRequired,
    int TotalQuestions,
    UnitResource Unit,
    IconResource Icon,
    IReadOnlyCollection<ExerciseResource> Exercises
);