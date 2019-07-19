using System.Linq;
using System.Threading.Tasks;
using ExpensesManaging.project.Contexts;
using ExpensesManaging.project.Models;
using ExpensesManaging.project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManaging.project.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            User user = await _userContext.Users.FindAsync(id);
            if(user == null)
            {
                return null; // TODO : Return NotFound
            }
            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser (User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction (nameof (GetUser), new { id = user.Id }, user);
        }
    }
}