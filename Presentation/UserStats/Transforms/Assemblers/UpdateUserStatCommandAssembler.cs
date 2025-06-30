using Domain.UserStats.Model.Agreggates;
using Presentation.UserStats.Resources;

namespace Presentation.UserStats.Transforms.Assemblers
{
    public static class UpdateUserStatCommandAssembler
    {
        public static UserStat ToEntity(UpdateUserStatResource resource)
        {
            return new UserStat
            {
                Lives = resource.Lives,
                Stars = resource.Stars,
                TotalLivesLost = resource.TotalLivesLost,
                TotalAdsWatched = resource.TotalAdsWatched,
                QuestionsComplete = resource.QuestionsComplete
            };
        }
    }
}



