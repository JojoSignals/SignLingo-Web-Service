using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.ValueObjects;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public static class AppDbContextSeed
{
    public static void LoadQuestionType(AppDbContext context)
    {
       
            if (!context.QuestionTypes.Any())
            {
                context.QuestionTypes.AddRange(
                    new QuestionTypeEntity {Id = 1, Qtype = QuestionType.SelectWord},
                    new QuestionTypeEntity {Id = 2, Qtype = QuestionType.SelectImage},
                    new QuestionTypeEntity {Id = 3, Qtype = QuestionType.ScanImage},
                    new QuestionTypeEntity {Id = 4, Qtype = QuestionType.ScanWord}
                    );
                context.SaveChanges();
            }
        
        
    }
    
    
}