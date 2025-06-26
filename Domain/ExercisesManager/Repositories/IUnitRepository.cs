using Domain.ExercisesManager.Model.Entities;
using Domain.Shared.Repository;

namespace Domain.ExercisesManager.Repositories;

public interface IUnitRepository : IBaseRepository<Unit>
{
    Task<Unit?> GetUnitByNameAsync(string name);
}