namespace Domain.Security.Model.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string Role { get; set; } 
    public bool IsVip { get; set; }
}