using Presentation.UserStats.Resources;
using Domain.UserStats.Model.Responses;

namespace Presentation.UserStats.Transforms.Assemblers
{
    public static class UserStatResourceAssembler
    {
        public static UserStatResource ToResource(UserStatsResponse entity)
        {
            return new UserStatResource(
                entity.Id,
                entity.Lives,
                entity.Stars,
                entity.TotalLivesLost,
                entity.TotalAdsWatched,
                entity.QuestionsComplete,
                entity.UserId
            );
        }
    }
}