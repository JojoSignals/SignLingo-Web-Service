using Domain.Security.Model.ValueObjects;
using Domain.Shared;

namespace Domain.Security.Model.Entities;

public class User : BaseModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public UserRoles Role { get; set; }
    public bool IsVip { get; set; }
}