using Domain.UserStats.Model.Agreggates;
using Presentation.UserStats.Resources;

namespace Presentation.UserStats.Transform.Assemblers;

public static class UserStatResourceAssembler
{
    public static UserStatResource ToResource(UserStat entity)
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