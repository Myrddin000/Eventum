using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventumAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class ReminderController : Controller
    {

        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpPost]
        public IActionResult Create(ReminderFormDTO remind)
        {
            try
            {
                _reminderService.Create(remind);
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
                return Ok(_reminderService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid Reminder_id)
        {
            try
            {
                return Ok(_reminderService.GetById(Reminder_id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(ReminderDTO remind)
        {
            try
            {
                _reminderService.Update(remind);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Reminder_id}")]
        public IActionResult Delete(Guid Reminder_id)
        {
            try
            {
                _reminderService.Delete(Reminder_id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
