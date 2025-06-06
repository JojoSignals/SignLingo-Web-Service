namespace Presentation.Security.Resources;

public record UpdateUserResource(
    string Username,
    string? ProfilePicture,
    string? CurrentPassword,
    string? NewPassword);