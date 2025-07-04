using Domain.UserStats.Model.Commands;
using Presentation.UserStats.Resources;

namespace Presentation.UserStats.Transforms.Assemblers;

public static class CreateUserStatCommandFromResourceAssembler
{
    public static CreateUserStatsCommand ToCommandFromResource(CreateUserStatResource resource)
    {
        return new CreateUserStatsCommand(resource.UserId);
    }

}
