using Application.Shared.Exceptions;

namespace Application.Security.Exceptions;

public class DuplicatedUserUsernameException : DuplicatedEntityAttributeException
{
    public DuplicatedUserUsernameException(object attributeValue)
        : base("User", "Username", attributeValue)
    {
        
    }
}