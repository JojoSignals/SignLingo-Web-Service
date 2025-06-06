namespace Presentation.Security.Resources;

public record SignInResource(string Email, string Password, string CaptchaResponse);