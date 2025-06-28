namespace Presentation.UserStats.Resources;

public record UpdateUserStatResource(int Lives, int Stars, int TotalLivesLost, int TotalAdsWatched, int QuestionsComplete);