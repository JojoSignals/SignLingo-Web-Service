namespace Application.Shared.Exceptions;

public class DuplicatedEntityAttributeException : ConflictException
{
    public string EntityName { get; }
    public string AttributeName { get; }
    public object AttributeValue { get; }
    
    public DuplicatedEntityAttributeException(string entityName, string attributeName, object attributeValue)
        :base($"The {entityName} with ({attributeName}: {attributeValue}) is already registered.")
    {
        
        EntityName = entityName;
        AttributeName = attributeName;
        AttributeValue = attributeValue;
    }
}