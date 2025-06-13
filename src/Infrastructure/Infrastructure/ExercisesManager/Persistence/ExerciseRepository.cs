using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.ExercisesManager.Persistence;

public class ExerciseRepository(AppDbContext context) : BaseRepository<Exercise>(context), IExerciseRepository
{
}