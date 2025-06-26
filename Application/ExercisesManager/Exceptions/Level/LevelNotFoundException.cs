using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions.Level;

public class LevelNotFoundException : NotFoundEntityIdException
{
    public LevelNotFoundException(int Id) : base("Level", Id)
    {
        
    }
}