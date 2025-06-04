namespace Presentation.Security.Resources;

public record UpdateUserResource(
    int Id,
    string Username,
    string? ProfilePicture,
    string? CurrentPassword,
    string? NewPassword);