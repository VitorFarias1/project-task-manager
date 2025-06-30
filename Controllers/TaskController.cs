using System.Net;
using Dtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ITaskService _service;

        public ApiController(ITaskService service) {
            _service = service;
        }
        
        [HttpGet("/task")]
        public IActionResult GetTasks()
        {
            _service.GetAll();
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