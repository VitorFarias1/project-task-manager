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
            var allTasks = _service.GetAllTasks();

            if (allTasks == null)
            {
                return NotFound();
            }

            return Ok(allTasks);
        }

        [HttpGet("/task/{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _service.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost("/task")]
        public IActionResult CreateTask([FromBody] TaskDto task)
        {
            if (task == null)
            {
                throw new Exception("Não foi possível criar a tarefa.");
            }
            _service.CreateTask(task);
            return Created();
        }

        [HttpPut("/task/{id}")]
        public IActionResult UpdateTask([FromBody] TaskDto taskDto, Guid id)
        {
           
            _service.UpdateTask(taskDto, id);
            return Ok();

        }

        [HttpDelete("/task/{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            _service.DeleteTask(id);
            return Ok();
        }

    }
}