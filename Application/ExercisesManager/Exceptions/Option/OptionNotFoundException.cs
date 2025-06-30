using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions.Option;

public class OptionNotFoundException : NotFoundEntityIdException
{
    public OptionNotFoundException(int id) : base("option", id)
    {
        
    }
}