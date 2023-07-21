using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        public IConfiguration _Configuration;


        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _AuthService = authService;
            _Configuration = configuration;
        }

        [HttpPost]
        [Produces(typeof(TokenDTO))]

        public IActionResult Post(LoginDTO loginDTO)
        {
            try
            {
                return Ok(_AuthService.Auth(loginDTO));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        } 
        
        
    }
}
