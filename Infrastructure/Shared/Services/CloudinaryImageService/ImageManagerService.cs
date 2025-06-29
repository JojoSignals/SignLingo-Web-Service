using System.Net;
using Domain.Shared.Model.Responses.ImageManager;
using Domain.Shared.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace Infrastructure.Shared.Services.CloudinaryImageService;

public class ImageManagerService: IImageManagerService
{

    private readonly Cloudinary _cloudinaryClient;

    public ImageManagerService(IOptions<CloudinaryCredentials> cloudinaryCredentials)
    {
        var credentials = cloudinaryCredentials.Value;

        Account account = new(credentials.CloudName, credentials.ApiKey,credentials.ApiSecret);
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
            return new ImageResponse(response.Url.ToString());
        }
        
        throw new Exception("Error uploading image");
    }
}