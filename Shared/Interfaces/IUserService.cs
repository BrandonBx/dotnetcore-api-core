namespace ExpensesManaging.Shared.Interfaces
{
    public interface IUserService
    {
         bool IsValidUser(string username, string password);
    }
}