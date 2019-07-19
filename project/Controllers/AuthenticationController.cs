using System.Text;
using System.Diagnostics;
using System.Reflection.Metadata;
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
        private readonly IUserService _userService;
        private readonly UserContext _userContext;
        private readonly AppSettings _appSettings;

        public AuthenticationController(
            IUserService userService, 
            UserContext userContext,
            IOptions<AppSettings> appSettings)
        {
            _userContext = userContext;
            _userService = userService;
            _appSettings = appSetting.value;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult<User> Login(User user)
        {
            User _user = _userService.Authenticate(user.Username, user.Password)
            if(_user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandle();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, _user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new {
                Id = _user.Id,
                Username = _user.Username,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<User> Register(User user)
        {
            try {
                _userService.Create(user);
                return Ok();
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}