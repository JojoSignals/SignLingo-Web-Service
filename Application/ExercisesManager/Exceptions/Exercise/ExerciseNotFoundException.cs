using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions.Exercise;

public class ExerciseNotFoundException : NotFoundEntityIdException
{
    public ExerciseNotFoundException(int Id) : base("Exercise", Id)
    {
        
    }
}