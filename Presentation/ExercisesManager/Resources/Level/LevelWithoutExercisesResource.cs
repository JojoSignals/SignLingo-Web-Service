using Presentation.ExercisesManager.Resources.Icon;
using Presentation.ExercisesManager.Resources.Unit;

namespace Presentation.ExercisesManager.Resources.Level;
public record LevelWithoutExercisesResource(
    int Id,
    string Name,
    int ExperienceRequired,
    int TotalQuestions,
    UnitResource Unit,
    IconResource Icon);
