using System;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManaging.POCO;
using ExpensesManaging.project.Entities;
using ExpensesManaging.project.POCO;
using ExpensesManaging.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManaging.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly UserContext _userContext;

        public AuthenticationController(IAuthenticateService authenticateService, UserContext userContext)
        {
            _userContext = userContext;
            _authenticateService = authenticateService;

        }

        [AllowAnonymous]
        [HttpPost, Route("request")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (_authenticateService.IsAuthenticated(request, out token))
            {
                return Ok();
            }

            return BadRequest("Invalid request");
        }
        [AllowAnonymous]
        [HttpGet("{email, password}"), Route("login")]
        public async Task<ActionResult<User>> login(string email, string password)
        {
            User user = await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return null;
        }
        [AllowAnonymous]
        [HttpPost, Route("register")]
        public async Task<ActionResult<User>> register(User user)
        {
            // Use a service for these things please
            byte[] salt = new byte[128/8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256/8
            ));

            user.Password = hashed;
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
            return CreatedAtAction (nameof (login), new { id = user.Id }, user); // TODO : Adapt the result please
        }
    }
}