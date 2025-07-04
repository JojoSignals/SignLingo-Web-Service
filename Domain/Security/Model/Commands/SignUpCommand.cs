namespace Domain.Security.Model.Commands;

public record SignUpCommand(string Username, string Email, string Password/*, string CaptchaResponse*/);