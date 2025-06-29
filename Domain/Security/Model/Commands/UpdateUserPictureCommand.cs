namespace Domain.Security.Model.Commands;

public record UpdateUserPictureCommand(
    int UserId,
    Stream PictureStream
);