namespace Domain.Security.Model.Commands;

public record UpdateUserCommand(
    int Id,
    string Username,
    string Email,
    string? ProfilePicture,
    string? CurrentPassword,
    string? NewPassword
    );