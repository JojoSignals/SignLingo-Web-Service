namespace Application.Shared.Exceptions;

public class NotFoundEntityIdException : NotFoundEntityAtrributeException
{
    public NotFoundEntityIdException(string entityName, int id)
        : base(entityName, "Id", id)
    {
    }
}