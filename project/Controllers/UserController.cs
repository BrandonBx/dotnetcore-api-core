using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.project.Contexts;
using DotnetCore.project.Models;
using DotnetCore.project.Services;
using DotnetCore.project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.project.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;   
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> users = await _userService.GetAll();
            
            if(users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<User>> GetUser(long id)
        // {
        //     User user = await _userService.Users.FindAsync(id);
        //     if(user == null)
        //     {
        //         return null; // TODO : Return NotFound
        //     }
        //     return user;
        // }
        // [HttpPost]
        // public async Task<ActionResult<User>> PostUser (User user)
        // {
        //     _userContext.Users.Add(user);
        //     await _userContext.SaveChangesAsync();

        //     return CreatedAtAction (nameof (GetUser), new { id = user.Id }, user);
        // }
    }
}