// CreateUserStatCommandAssembler.cs
using Domain.UserStats.Model.Agreggates;
using Presentation.UserStats.Resources;

namespace Presentation.UserStats.Transforms.Assemblers
{
    public static class CreateUserStatCommandAssembler
    {
        public static UserStat ToEntity(CreateUserStatResource resource)
        {
            return new UserStat
            {
                Lives = resource.Lives,
                Stars = resource.Stars,
                TotalLivesLost = resource.TotalLivesLost,
                TotalAdsWatched = resource.TotalAdsWatched,
                QuestionsComplete = resource.QuestionsComplete,
                UserId = resource.UserId
            };
        }
    }
}

  

