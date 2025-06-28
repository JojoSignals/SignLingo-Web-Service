namespace Domain.UserStats.Model.Responses;

public class UserStatsResponse
{
    public int Id { get; set; }
    public int Lives { get; set; }
    public int Stars { get; set; }
    public int TotalLivesLost { get; set; }
    public int TotalAdsWatched { get; set; }
    public int QuestionsComplete { get; set; }
    public int UserId { get; set; }
}
