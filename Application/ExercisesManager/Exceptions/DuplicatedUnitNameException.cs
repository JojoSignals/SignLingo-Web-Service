using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions;

public class DuplicatedUnitNameException : DuplicatedEntityAttributeException
{
    public DuplicatedUnitNameException(string atributo, object valor)
        : base("Unidad", atributo, valor)
    {
        
    }
}