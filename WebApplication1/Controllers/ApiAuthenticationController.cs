using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAuthenticationController : ControllerBase
    {
        private readonly IAuthenticationInterface _authenticationInterface;
        public ApiAuthenticationController(IAuthenticationInterface authenticationInterface)
        {
          _authenticationInterface = authenticationInterface;
        }
        [HttpPost]
        [Route("Authentication")]
        public async Task<IActionResult> AuthenticationLogin([FromBody] Requestloginentity requestloginentity )
        {

            // Validate user credentials (hardcoded for example purposes)
            if (requestloginentity.Username == "rajkumar" && requestloginentity.Password == "password")
            {
                var token = await _authenticationInterface.AuthenticateAsync("1", "testuser");
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials.");
        }
    }
}
