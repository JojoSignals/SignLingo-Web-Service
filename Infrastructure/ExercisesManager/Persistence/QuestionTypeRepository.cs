using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.ExercisesManager.Persistence;

public class QuestionTypeRepository: BaseRepository<QuestionTypeEntity>, IQuestionTypeRepository
{
    public QuestionTypeRepository(AppDbContext context) : base(context)
    {
        
    }
}