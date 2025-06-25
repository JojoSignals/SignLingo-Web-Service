using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions;

public class UnitNotFoundException : NotFoundEntityIdException
{
    public UnitNotFoundException(int Id) : base("Unit", Id)
    {
        
    }
}