namespace Presentation.Security.Resources;
using Microsoft.AspNetCore.Http;

public record UpdateUserPictureResource(IFormFile File);