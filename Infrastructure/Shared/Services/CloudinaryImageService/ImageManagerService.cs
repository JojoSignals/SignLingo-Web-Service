using System.Net;
using Domain.Shared.Model.Responses.ImageManager;
using Domain.Shared.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.ExercisesManager.Model.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Shared.Services.CloudinaryImageService;

public class ImageManagerService : IImageManagerService
{
    private readonly Cloudinary _cloudinaryClient;

    public ImageManagerService(IOptions<CloudinaryCredentials> options)
    {
        var settings = options.Value;


        Account account = new(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        this._cloudinaryClient = new Cloudinary(account);
    }

    public async Task<ImageResponse> UploadAsync(string filename, Stream mediaStream, MediaType mediaType)
    {
        UploadResult response;

        if (mediaType == MediaType.VIDEO)
        {
            var videoParams = new VideoUploadParams()
            {
                File = new FileDescription(filename, mediaStream),
                //PublicId = filename
            };

            response = await _cloudinaryClient.UploadAsync(videoParams);
        }
        else
        {
            var imageParams = new ImageUploadParams()
            {
                File = new FileDescription(filename, mediaStream),
                //PublicId = filename
            };

            response = await _cloudinaryClient.UploadAsync(imageParams);
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return new ImageResponse(response.Url.ToString());
        }

        throw new Exception("Error uploading media");
    }
}