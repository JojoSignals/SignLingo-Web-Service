using Presentation.UserStats.Resources;
using Domain.UserStats.Model.Responses;

namespace Presentation.UserStats.Transforms.Assemblers
{
    public static class UserStatResourceAssembler
    {
        public static UserStatResource ToResource(UserStatsResponse entity)
        {
            Console.WriteLine("[DEBUG] " + entity.UserCompletedExercises);

            return new UserStatResource(
                entity.Id,
                entity.Lives,
                entity.Stars,
                entity.TotalLivesLost,
                entity.TotalAdsWatched,
                [.. entity.UserCompletedExercises.Select(e => e.ExerciseId)],
                entity.UserId
            );
        }
    }
}