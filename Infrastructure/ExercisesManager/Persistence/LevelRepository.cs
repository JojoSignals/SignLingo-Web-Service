using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExercisesManager.Persistence;

public class LevelRepository : BaseRepository<Level>, ILevelRepository
{
    public LevelRepository(AppDbContext context) : base(context)
    {
    }

    protected override IQueryable<Level> IncludeNavigationProperties(DbSet<Level> dbSet)
    {
        return dbSet.Include(l => l.Unit).Include(l => l.Icon).Include(l => l.Exercises)
            .ThenInclude(e => e.ExerciseOptions).ThenInclude(eo => eo.Option).AsSplitQuery();
    }
}