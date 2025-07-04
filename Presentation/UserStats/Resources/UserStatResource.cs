namespace Presentation.UserStats.Resources;

public record UserStatResource(
    int Id,
    int Lives,
    int Stars,
    int TotalLivesLost,
    int TotalAdsWatched,
    List<int> ExerciseCompletedIds,
    int UserId);