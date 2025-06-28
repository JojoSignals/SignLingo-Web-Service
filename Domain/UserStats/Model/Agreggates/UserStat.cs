using Domain.Shared;

namespace Domain.UserStats.Model.Agreggates;

public class UserStat : BaseModel
{
    public int Lives { get; set; }
    public int Stars { get; set; }
    public int TotalLivesLost { get; set; }
    public int TotalAdsWatched { get; set; }
    public int QuestionsComplete { get; set; }

    // FK hacia User
    public int UserId { get; set; }
}