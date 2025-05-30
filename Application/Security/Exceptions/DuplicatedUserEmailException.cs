using Application.Shared.Exceptions;

namespace Application.Security.Exceptions;

public class DuplicatedUserEmailException : DuplicatedEntityAttributeException
{
    public DuplicatedUserEmailException(object attributeValue)
        : base("User", "Email", attributeValue)
    {
        
    }
    
}