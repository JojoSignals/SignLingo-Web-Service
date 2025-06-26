using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions.Unit;

public class UnitNotFoundException : NotFoundEntityIdException
{
    public UnitNotFoundException(int Id) : base("Unit", Id)
    {
        
    }
}