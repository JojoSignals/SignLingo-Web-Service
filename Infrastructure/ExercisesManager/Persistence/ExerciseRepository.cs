using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExercisesManager.Persistence;

public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IReadOnlyCollection<Exercise>> GetAllExercisesByQuestionTypeIdAsync(int questionTypeId)
    {
        return await _context.Exercises
            .Where(e => e.QuestionTypeId == questionTypeId && e.IsEnable == true)
            .ToListAsync();

    }
    
    protected override IQueryable<Exercise> IncludeNavigationProperties(DbSet<Exercise> dbSet)
    {
        return dbSet.Include(e => e.ExerciseOptions).ThenInclude(eo => eo.Option);
    }
}
