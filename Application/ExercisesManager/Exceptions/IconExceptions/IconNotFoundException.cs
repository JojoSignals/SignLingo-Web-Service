using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions.IconExceptions;

public class IconNotFoundException : NotFoundEntityIdException
{
    public IconNotFoundException(int id) : base("Icon", id)
    {
        
    }
}