using Application.Shared.Exceptions;

namespace Application.Security.Exceptions;

public class InvalidCurrentException : ValidationException
{
    public InvalidCurrentException()
        : base("Current password is incorrect")
    {
        
    }
}