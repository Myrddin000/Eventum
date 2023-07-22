
using BLL.Interfaces;
using BLL.Models;
using BLL.Tools;
using Microsoft.AspNetCore.Mvc;

namespace EventumAPI.Controllers
{
    // 
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {

        // Liaison avec la BLL (Son Interface 'IUserServices' + Le nom '_userServices')
        private readonly IUserService _userService;
        // Construction de l'appel (Son Services 'UserController' avec comme params Interface 'IUserServices' et son nom et dans ce constructeur faire l'appel de liaison DAL 'userServices')
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    //



        [HttpPost]
        public IActionResult Create(UserFormDTO user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(UserDTO user)
        {
            try
            {
                _userService.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{User_id}")]
        public IActionResult Delete(Guid User_id)
        {
            try
            {
                _userService.Delete(User_id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid User_id)
        {
            try
            {
                return Ok(_userService.GetById(User_id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
