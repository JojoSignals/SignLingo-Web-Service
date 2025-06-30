using System.Net;
using Domain.Shared.Model.Responses.ImageManager;
using Domain.Shared.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Shared.Services.CloudinaryImageService;

public class ImageManagerService : IImageManagerService
{
    private readonly Cloudinary _cloudinaryClient;
<<<<<<< Updated upstream
    private string _apiKey; 
=======
>>>>>>> Stashed changes

    public ImageManagerService(IOptions<CloudinaryCredentials> options)
    {

        var settings = options.Value;

<<<<<<< Updated upstream
        this._apiKey = settings.ApiKey;
=======
>>>>>>> Stashed changes
        Account account = new(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        this._cloudinaryClient = new Cloudinary(account);
    }

    public async Task<ImageResponse> UploadAsync(string filename, Stream imageStream)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(filename, imageStream)
        };
        var response = await _cloudinaryClient.UploadAsync(uploadParams);

        if (response.StatusCode == HttpStatusCode.OK)
        {
<<<<<<< Updated upstream
            Console.WriteLine("URL IS " + response.Url.ToString());
            Console.WriteLine("API KEY " + this._apiKey);
=======
>>>>>>> Stashed changes
            return new ImageResponse(response.Url.ToString());
        }

        throw new Exception("Error uploading image");
    }
}