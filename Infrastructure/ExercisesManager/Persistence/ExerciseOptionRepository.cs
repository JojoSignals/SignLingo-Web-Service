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
            .Where(x => x.ExerciseId == exerciseId)
            .ToListAsync();
    }
}