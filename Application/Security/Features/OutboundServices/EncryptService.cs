using Domain.Security.Services;

namespace Application.Security.Features.CommandServices;

public class EncryptService : IEncryptService
{
    public string Encrypt(string password)
    {
        throw new NotImplementedException();
    }

    public bool Verify(string password, string passwordHashed)
    {
        throw new NotImplementedException();
    }
}