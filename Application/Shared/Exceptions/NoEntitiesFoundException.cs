namespace Application.Shared.Exceptions;

public class NoEntitiesFoundException : NotFoundException
{
    public string EntityName { get; }

    public NoEntitiesFoundException(string entityName)
        : base($"No '{entityName}' found")
    {
        EntityName = entityName;
    }
}
