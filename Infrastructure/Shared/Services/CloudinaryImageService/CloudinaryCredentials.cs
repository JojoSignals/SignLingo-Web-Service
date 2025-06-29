namespace Infrastructure.Shared.Services.CloudinaryImageService;

public class CloudinaryCredentials(string cloudName, string apiKey, string apiSecret)
{
    public string CloudName { get; } = cloudName;
    public string ApiKey { get; } = apiKey;
    public string ApiSecret { get; } = apiSecret;
}