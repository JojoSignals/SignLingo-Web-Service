using Domain.Shared;

namespace Domain.Ranking.Model.Entities;

public class RankingEntry : BaseModel
{
    public string Username { get; set; } = string.Empty;
    public int Stars { get; set; }
}