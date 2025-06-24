using Application.Shared.Exceptions;

namespace Application.ExercisesManager.Exceptions;

public class IconNotFoundException : NotFoundEntityIdException
{
    public IconNotFoundException(int id) : base("Icon", id)
    {
        
    }
}