using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.ExercisesManager.Persistence;

public class OptionRepository : BaseRepository<Option>, IOptionRepository
{
    public OptionRepository(AppDbContext context) : base(context)
    {
        
    }
}