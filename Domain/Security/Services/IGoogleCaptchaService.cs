namespace Domain.Security.Services;

public interface IGoogleCaptchaService
{
    Task<bool> ValidateAsync(string captchaResponse);
}