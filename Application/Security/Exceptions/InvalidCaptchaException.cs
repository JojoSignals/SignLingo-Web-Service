using Application.Shared.Exceptions;

namespace Application.Security.Exceptions;

public class InvalidCaptchaException : ValidationException
{
    public InvalidCaptchaException()
        : base("Captcha validation failed.")
    {
        
    }
}