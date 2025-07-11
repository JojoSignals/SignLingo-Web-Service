namespace Domain.Ranking.Model.Entities;

public class RankingEntry
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? ProfilePictureUrl { get; set; }= string.Empty;
    public int Stars { get; set; }
    public int Position { get; set; }
    public bool IsCurrentUser { get; set; }
}