using System.Threading.Tasks;
using ExpensesManaging.POCO;
using ExpensesManaging.project.Entities;
using ExpensesManaging.project.POCO;
using ExpensesManaging.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return null;
        }
        [AllowAnonymous]
        [HttpPost, Route("login")]
        public async Task<ActionResult<User>> register(User user)
        {
            return null;
        }
    }
}