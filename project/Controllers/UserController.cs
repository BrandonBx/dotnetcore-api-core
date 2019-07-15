using System.Threading.Tasks;
using ExpensesManaging.project.Entities;
using ExpensesManaging.project.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManaging.project.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController (UserContext context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            User user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return null; // TODO : Return NotFound
            }
            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser (User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction (nameof (GetUser), new { id = user.Id }, user);
        }
    }
}