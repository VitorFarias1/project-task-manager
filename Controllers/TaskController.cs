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

        }

        [HttpGet("/task/{id}")]
        public IActionResult GetTaskById(Guid id)
        {

        }

        [HttpPost("/task")]
        public IActionResult CreateTask([FromBody] TaskDto task)
        {

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