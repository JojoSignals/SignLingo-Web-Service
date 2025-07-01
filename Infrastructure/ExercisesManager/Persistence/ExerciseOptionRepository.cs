using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExercisesManager.Persistence;

public class ExerciseOptionRepository : BaseRepository<ExerciseOption>, IExerciseOptionRepository
{
    public ExerciseOptionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<ExerciseOption>> GetExerciseOptionsByExerciseIdAsync(int exerciseId)
    {
        return await _context.ExerciseOptions
            .Include(x => x.Exercise)
            .Include(x => x.Option)
            .Where(x => x.ExerciseId == exerciseId)
            .ToListAsync();
    }


    protected override IQueryable<ExerciseOption> IncludeNavigationProperties(DbSet<ExerciseOption> dbSet)
    {
        return dbSet.Include(x => x.Exercise).Include(x => x.Option);
    }
}