namespace Domain.Shared.Model.Responses.ImageManager;

public class ImageResponse(string url)
{
    public string Url { get; set; } = url;
}