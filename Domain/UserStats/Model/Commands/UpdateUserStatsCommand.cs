namespace Domain.UserStats.Model.Commands;

public record UpdateUserStatsCommand(int UserStatsId, int? Lives, int? Stars, int? TotalLivesLost, int? TotalAdsWatched, int? QuestionsComplete);
