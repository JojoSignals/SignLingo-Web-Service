using Domain.Security.Model.Commands;
using Presentation.Security.Resources;

namespace Presentation.Security.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password, resource.CaptchaResponse);
    }
}