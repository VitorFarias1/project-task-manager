using System.Net;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        
        [HttpGet("/task")]
        public IActionResult GetTasks()
        {
            return Ok();
        }

        [HttpGet("/task/{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            return Ok();
        }

        [HttpPost("/task")]
        public IActionResult CreateTask([FromBody] TaskDto task)
        {
            return Created();
        }

        [HttpPut("/task/{id}")]
        public IActionResult UpdateTask(Guid id)
        {
            
        }

        [HttpDelete("/task/{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            
        }

    }
}