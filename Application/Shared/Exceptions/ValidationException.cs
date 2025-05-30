namespace Application.Shared.Exceptions;

public class ValidationException : Exception
{
    protected ValidationException(string message) 
        : base(message)
    {
        
    }
}