using Domain.UserStats.Model.Commands;
using Presentation.UserStats.Resources;

namespace Presentation.UserStats.Transforms.Assemblers;
public static class UpdateUserStatCommandFromResourceAssembler
{

    public static UpdateUserStatsCommand ToCommandFromResource(int id, UpdateUserStatResource resource)
    {
        return new UpdateUserStatsCommand(
            id, resource.Lives, resource.Stars, resource.TotalLivesLost, resource.TotalAdsWatched, resource.QuestionsComplete
            );

    }
}
