using Domain.Shared;
using Domain.UserStats.Model.ValueObjects;

namespace Domain.UserStats.Model.Agreggates;

public class UserStat : BaseModel
{
    public int Lives { get; set; } = 5;
    public int Stars { get; set; } = 0;
    public int TotalLivesLost { get; set; } = 0;
    public int TotalAdsWatched { get; set; } = 0;

    public List<UserCompletedExercise> UserCompletedExercises { get; set; } = [];
    // FK hacia User
    public int UserId { get; set; }
}