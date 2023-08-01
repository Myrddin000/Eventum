using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventumAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventController : Controller
    {

        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }



        [HttpPost]
        public IActionResult Create(EventFormDTO even)
        {
            try
            {
                _eventService.Create(even);
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
                return Ok(_eventService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid Event_id)
        {
            try
            {
                return Ok(_eventService.GetById(Event_id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(EventDTO even)
        {
            try
            {
                _eventService.Update(even);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                    
            }
        }

        [HttpDelete("{Event_id}")]
        public IActionResult Delete(Guid Event_id)
        {
            try
            {
                _eventService.Delete(Event_id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
