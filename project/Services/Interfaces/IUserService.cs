using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetCore.project.Models;

namespace DotnetCore.project.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}