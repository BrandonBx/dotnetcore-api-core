using ExpensesManaging.Shared.Interfaces;

namespace ExpensesManaging.project.Services
{
    public class UserManagementService : IUserService
    {
        
        // TODO : Don't never return true in production. Return instead the identity of the user
        public bool IsValidUser(string username, string password)
        {
            return true;
        }
    }
}