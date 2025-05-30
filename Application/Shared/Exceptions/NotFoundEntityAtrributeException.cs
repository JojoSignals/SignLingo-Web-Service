namespace Application.Shared.Exceptions;

public class NotFoundEntityAtrributeException : NotFoundException
{
    public string EntityName { get; }
    public string AttributeName { get; }
    public object AttributeValue { get; }
    
    public NotFoundEntityAtrributeException(string entityName, string attributeName, object attributeValue)
        : base($"The {entityName} with {attributeName} '{attributeValue}' was not found.")
    {
        EntityName = entityName;
        AttributeName = attributeName;
        AttributeValue = attributeValue;
    }
    
}