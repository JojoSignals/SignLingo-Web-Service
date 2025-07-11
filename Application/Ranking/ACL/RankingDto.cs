namespace Application.Ranking.ACL;

public class RankingDto
{
    public int UserId { get; set; } // ← antes era Guid
    public string Username { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public int Stars { get; set; }
    public int Position { get; set; }
    public bool IsCurrentUser { get; set; }
}