using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManaging.Controllers {
    [Authorize]
    [Route ("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        public AuthenticationController()
        {

        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate()
        {
            
        }
    }
}