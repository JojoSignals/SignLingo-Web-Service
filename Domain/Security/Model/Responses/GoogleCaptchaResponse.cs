namespace Domain.Security.Model.Responses;

public class GoogleCaptchaResponse
{
    public bool Success { get; set; }
    public DateTime ChallengeTimestamp { get; set; }
    public string Hostname { get; set; }
    public List<string> ErrorCodes { get; set; }
}