using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Security.Model.Entities;
using Domain.Security.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public static class AppDbContextSeed
{
    public static void LoadQuestionType(AppDbContext context)
    {

        if (!context.QuestionTypes.Any())
        {
            context.QuestionTypes.AddRange(
                new QuestionTypeEntity { Id = 1, Qtype = QuestionType.SelectWord },
                new QuestionTypeEntity { Id = 2, Qtype = QuestionType.SelectImage },
                new QuestionTypeEntity { Id = 3, Qtype = QuestionType.ScanImage },
                new QuestionTypeEntity { Id = 4, Qtype = QuestionType.ScanWord }
                );
            context.SaveChanges();
        }


    }


    public static async Task LoadUsersDataAsync(AppDbContext context)
    {
        // Evita duplicar el registro cada vez que arranca la app
        if (await context.Users.AnyAsync()) return;

        var user = new User()
        {
            Username         = "elweoficial",
            Email            = "elwe@gmail.com",
            PasswordHash     = "$2a$11$v4wQH80zj.C6gOrG4qiGQOAo0IeH7OjgV6yg2Zl2juwMPUeg8HkFm",
            ProfilePictureUrl = null,    
            Role             = UserRoles.ADMIN,
            IsVip            = false
        };

        try
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error saving users in database", ex);
        }
    }

}