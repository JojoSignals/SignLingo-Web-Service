using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.ExercisesManager.Persistence;

public class UnitRepository : BaseRepository<Unit>, IUnitRepository
{
    public UnitRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Unit?> GetUnitByNameAsync(string name)
    {
        return await _context.Units
            .Where(unit => unit.Name == name)
            .FirstOrDefaultAsync();
          
    }
}