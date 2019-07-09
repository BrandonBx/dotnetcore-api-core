using ExpensesManaging.POCO;

namespace ExpensesManaging.Shared.Interfaces
{
    public interface IAuthenticateService
    {
         bool IsAuthenticated(TokenRequest resquest, out string token);
    }
}