namespace Presentation.Security.Resources;

public record SignUpResource(string Username, string Email, string Password, string CaptchaResponse);