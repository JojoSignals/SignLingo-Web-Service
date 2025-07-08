using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Shared.Model.Responses.ImageManager;

namespace Domain.Shared.Services;

public interface IImageManagerService
{
    Task<ImageResponse> UploadAsync(string filename, Stream mediaStream, MediaType mediaType);
}