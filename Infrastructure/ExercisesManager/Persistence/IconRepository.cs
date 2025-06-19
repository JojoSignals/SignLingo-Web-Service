using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.ExercisesManager.Persistence;

public class IconRepository : BaseRepository<Icon>, IIconRepository
{
    public IconRepository(AppDbContext context) : base(context)
    {
    }
}