namespace Presentation.UserStats.Resources;

public record CreateUserStatResource(int Lives, int Stars, int TotalLivesLost, int TotalAdsWatched, int QuestionsComplete, int UserId);