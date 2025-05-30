using Application.Shared.Exceptions;

namespace Application.Security.Exceptions;

public class InvalidCredentialsException : ValidationException
{
    public InvalidCredentialsException()
        : base("Invalid email or password")
    {
        
    }
}