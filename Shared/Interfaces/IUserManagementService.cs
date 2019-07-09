namespace ExpensesManaging.Shared.Interfaces
{
    public interface IUserManagementService
    {
         bool IsValidUser(string username, string password);
    }
}