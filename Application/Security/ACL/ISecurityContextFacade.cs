namespace Application.Security.ACL;

public interface ISecurityContextFacade
{
    int FetchUserIdByToken(string token);
}