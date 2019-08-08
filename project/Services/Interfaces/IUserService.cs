using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetCore.project.Models;

namespace DotnetCore.project.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(long id);
        Task<User> Create(User user, string password);
        Task<User> Update(User user, string password = null);
        void Delete(int id);
    }
}